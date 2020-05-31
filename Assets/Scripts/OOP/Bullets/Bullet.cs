using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace Game
{
	public class Bullet : SerializedMonoBehaviour
	{
		[Tooltip("Bullets to be made are: " +
			"BulletInteractable (an area that reacts to a bullet that enters it)" +
			"Matryoshka (intended to work through the composite pattern and delegate events)")]

		[Header("Bullet")]
		public float m_LifeTime = 10f;
		public List<Shooter> m_Shooters;
		public float m_Damage = 10.0f;

		[Header("Bullet - readonly")]
		[ReadOnly] public Vector3 m_ShootDirection; // Direction towards which the bullet was originally shot
		[ReadOnly] public BezierSpline m_Motor;

		[HideInInspector] public Rigidbody _rb;

		#region Events
		public delegate void Event(Bullet instance);
		private Event onBirth, onDeath;
		public Event OnBirth { get => onBirth; set => onBirth = value; }
		public Event OnDeath { get => onDeath; set => onDeath = value; }
		#endregion
		#region Creation
		public virtual Bullet Instantiate(Vector3 position, Transform parent)
		{
			return Instantiate(this, position, Quaternion.identity);
		}
		public void Init(LayerMask layer, Vector3 shootDirection, BezierSpline pattern = null)
		{
			gameObject.layer = layer.value;
			m_Motor = pattern;
			m_ShootDirection = shootDirection;
		}
		#endregion
		#region Translation
		public virtual Vector3 GetVelocity(float t)
		{
			return m_Motor.GetFinalVelocity(t);
		}
		public IEnumerator Travel()
		{
			float birthTime = Time.time;

			while (this != null)
			{
				float t = Time.time - birthTime;
				transform.position += GetVelocity(t);
				_rb.angularVelocity = m_ShootDirection;
				yield return null;
			}
		}
		#endregion
		#region OnDeath
		delegate void Fn();
		private IEnumerator WaitAndDo(float seconds, Fn fn)
		{
			while (seconds > 0.0f)
			{
				seconds -= Time.deltaTime;
				yield return null;
			}
			fn?.Invoke();
			Helper.Destroy(gameObject);
		}
		private void OnDeathSpawn()
		{
			foreach (Shooter s in m_Shooters)
			{
				Shooter instance = Instantiate(s, transform.position, Quaternion.identity, null) as Shooter;
				// instance.CleanSplines();
				// instance.CreateSplines();
				instance.Shoot(gameObject.layer, true);
				// Helper.Destroy(instance.gameObject);
			}
		}
		private void DestroyWhenNotNeeded()
		{

		}
		#endregion
		#region OnCollision
		protected virtual void TakeDamage(float dmg)
		{
			Debug.Log("On taking damage");
		}
		protected virtual void OnDoDamage()
		{
			Debug.Log("On doing damage");
		}
		bool Compare(LayerMask first, LayerMask second)
		{
			return (first == second);
		}
		private void OnCollisionEnter(Collision collision)
		{
			GameObject other = collision.collider.gameObject;

			LayerMask	playerMask			= LayerMask.NameToLayer("Player"),
						playerBulletMask	= LayerMask.NameToLayer("Player bullet"),
						enemyMask			= LayerMask.NameToLayer("Enemy"),
						enemyBulletMask		= LayerMask.NameToLayer("Enemy bullet");

			if (Compare(gameObject.layer, playerBulletMask))
			{
				if (Compare(other.layer, enemyBulletMask))
				{
					dynamic otherBullet = other.GetComponent<Bullet>();
					otherBullet?.TakeDamage(m_Damage);
					OnDoDamage();
				}
				else if (Compare(other.layer, enemyMask))
				{
					Enemy otherEnemy = other.GetComponent<Enemy>();
					otherEnemy?.TakeDamage(m_Damage);
					OnDoDamage();
				}
			}
			else if (Compare(gameObject.layer, enemyBulletMask))
			{
				if (Compare(other.layer, playerBulletMask))
				{
					dynamic otherBullet = other.GetComponent<Bullet>();
					otherBullet?.TakeDamage(m_Damage);
					OnDoDamage();
				}
				else if (Compare(other.layer, playerMask))
				{
					PlayerController otherPlayer = other.GetComponent<PlayerController>();
					otherPlayer?.TakeDamage(m_Damage);
					OnDoDamage();
				}
			}
		}
		#endregion

		#region Unity Events
		private void Awake()
		{
			_rb = GetComponent<Rigidbody>();
			if (_rb == null)
			{
				_rb = gameObject.AddComponent<Rigidbody>();
			}
			_rb.useGravity = false;
			// _rb.isKinematic = true;
			StartCoroutine(WaitAndDo(m_LifeTime, OnDeathSpawn));
		}
		private void Start()
		{
			OnBirth?.Invoke(this);
		}
		private void Update()
		{
		}
		private void OnDestroy()
		{
			StopCoroutine(Travel());
			OnDeath?.Invoke(this);
		}
		#endregion


	}
}