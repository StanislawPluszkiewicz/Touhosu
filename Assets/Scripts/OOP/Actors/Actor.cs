using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game
{
	[RequireComponent(typeof(Rigidbody))]
	public class Actor : SerializedMonoBehaviour
	{
		[Title("Movement")]
		[SerializeField] protected float m_Height;

		[SerializeField] protected float m_AngularSpeed;
		protected Vector3 m_Velocity;

		protected float m_TimeSinceBirth = 0.0f;

		public Vector3 Velocity { get => m_Velocity; }
		public float AngularSpeed { get => m_AngularSpeed; }


		[Title("Shoot")]
		protected bool m_DoShoot;
		Weapon[] m_Weapons;


		protected Transform _transform;
		protected Rigidbody _rb;
		protected Camera _cam;

		protected virtual LayerMask GetProjectileLayerMask()
		{
			Debug.LogError("GetLayerMask", this);
			return LayerMask.NameToLayer("None");
		}

		#region UnityEvents
		protected virtual void Awake()
		{
			_transform = transform;
			_rb = GetComponent<Rigidbody>();
		}
		protected virtual void Start()
		{
			_cam = Camera.main;
			if (_cam == null) Debug.LogError("Make sure to tag a camera with the MainCamera tag!", this);

			m_Weapons = GetComponentsInChildren<Weapon>();
			if (m_Weapons.Length == 0) Debug.LogError("Actor has no weapons!", this);

			foreach (Weapon w in m_Weapons)
			{
				w.ProjectileLayer = GetProjectileLayerMask();
			}


			StartCoroutine(Move());
		}
		protected virtual void Update()
		{
			Shoot();
			m_TimeSinceBirth += Time.deltaTime;
		}
		#endregion
		#region Movement
		protected virtual Vector3 GetMoveInput()
		{
			Debug.LogError("GetMoveInput", this);
			return Vector3.zero;
		}
		public IEnumerator Move()
		{
			float startTime = Time.time;

			while (this)
			{
				m_Velocity = GetMoveInput();

				transform.position += m_Velocity;
				transform.position = Boundary.ClampPosition(transform.position, m_Height);
				startTime += Time.deltaTime;
				yield return null;
			}
		}
		#endregion
		#region Shoot
		protected virtual bool GetShootInput()
		{
			Debug.LogError("GetShootInput", this);
			return false;
		}
		public void Shoot()
		{
			m_DoShoot = GetShootInput();
			if (m_DoShoot)
			{
				foreach (Weapon w in m_Weapons)
				{
					w.Shoot();
				}
			}
		}
		#endregion
	}

}