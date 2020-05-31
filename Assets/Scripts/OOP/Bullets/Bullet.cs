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

		[Header("Bullet - readonly")]
		[ReadOnly] public Vector3 m_ShootDirection; // Direction towards which the bullet was originally shot
		[ReadOnly] public BezierSpline m_Motor;

		[HideInInspector] public Rigidbody _rb;

		#region Events
		public delegate void Event();
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
			gameObject.layer = layer;
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
				transform.position += m_Motor.GetFinalVelocity(t);
				_rb.angularVelocity = m_ShootDirection;
				yield return null;
			}
		}
		#endregion

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
				instance.Shoot(gameObject.layer);
				Helper.Destroy(instance.gameObject);
			}
		}

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
			OnBirth?.Invoke();
		}
		private void Update()
		{
		}
		private void OnDestroy()
		{
			StopCoroutine(Travel());
			// OnDeath?.Invoke();
		}
		#endregion


	}
}