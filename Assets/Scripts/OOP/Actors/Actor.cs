﻿using Sirenix.OdinInspector;
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
		[SerializeField] protected float m_TranslateSpeed;
		[SerializeField, ReadOnly] protected Vector3 m_Velocity;

		[SerializeField, ReadOnly] protected float m_BirthTime = 0.0f;

		public Vector3 Velocity { get => m_Velocity; }
		public float AngularSpeed { get => m_AngularSpeed; }


		[Title("Shoot")]
		protected bool m_DoShoot;
		Weapon[] m_Weapons;


		protected Transform _transform;
		protected Rigidbody _rb;
		protected Camera _cam;

		protected bool isSubjectToBoundaries = false;

		#region Collisions
		public void TakeDamage(float dmg)
		{
			Debug.Log("Ship taking damage");
		}
		protected virtual LayerMask GetProjectileLayerMask()
		{
			Debug.LogError("GetLayerMask", this);
			return LayerMask.NameToLayer("None");
		}
		#endregion

		#region UnityEvents
		protected virtual void Awake()
		{
			m_BirthTime = Time.time;
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
			if (SlowDownTime())
			{
				Time.timeScale = 0.5f;
			}
			else
			{
				Time.timeScale = 1.0f;
			}
		}
		#endregion

		protected virtual bool SlowDownTime()
		{
			Debug.LogError("GetMoveInput", this);
			return false;
		}

		#region Movement
		protected virtual Vector3 GetMoveInput(float timeSinceBirth)
		{
			Debug.LogError("GetMoveInput", this);
			return Vector3.zero;
		}
		public IEnumerator Move()
		{
			m_BirthTime = Time.time;

			while (this != null)
			{
				m_Velocity = GetMoveInput(Time.time - m_BirthTime);

				Vector3 newPosition = transform.position + m_Velocity;

				if(isSubjectToBoundaries)
					newPosition = Boundary.ClampPosition(newPosition, m_Height);

				transform.position = newPosition;
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