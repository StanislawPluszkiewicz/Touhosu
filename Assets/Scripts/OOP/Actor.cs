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
		[SerializeField] protected float m_Speed;

		[SerializeField] protected float m_AngularSpeed;
		protected Vector3 m_MovementDirection;

		protected float m_TimeSinceBirth = 0.0f;

		public Vector3 MovementDirection { get => m_MovementDirection; }
		public float AngularSpeed { get => m_AngularSpeed; }


		[Title("Shoot")]
		protected bool m_DoShoot;
		Weapon[] m_Weapons;


		protected Transform _transform;
		protected Rigidbody _rb;
		protected Camera _cam;


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
			if (m_Weapons.Length == 0) Debug.LogWarning("Actor has no weapons!", this);



			StartCoroutine(Move());
		}
		protected virtual void Update()
		{
			Shoot();
			m_TimeSinceBirth += Time.deltaTime;
		}
		#endregion
		#region Movement
		protected virtual void GetMoveInput() { }
		public IEnumerator Move()
		{
			float startTime = Time.time;

			while (true)
			{
				GetMoveInput();

				transform.position += GetVelocity(startTime);
				transform.position = Boundary.ClampPosition(transform.position, m_Height);
				startTime += Time.deltaTime;
				yield return null;
			}
		}

		public virtual Vector3 GetVelocity(float t)
		{
			Debug.LogError("bien tenté", this);
			return Vector3.zero;
		}
		#endregion
		#region Shoot
		protected virtual void GetShootInput() { }
		public void Shoot()
		{
			GetShootInput();
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