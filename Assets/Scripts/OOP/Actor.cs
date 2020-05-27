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
		[SerializeField] protected float m_Speed;

		[SerializeField] protected float m_AngularSpeed;
		[SerializeField] protected float m_Tilt;
		protected Vector3 m_MovementDirection;
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
		}
		protected virtual void Update()
		{
			Move();
			Shoot();
		}
		#endregion
		#region Movement
		protected virtual void GetMoveInput() { }
		public void Move()
		{
			GetMoveInput();

			Vector3 velocity = m_MovementDirection * m_Speed * Time.deltaTime;
			transform.position = Boundary.ClampPosition(transform.position + velocity, m_Height);

			Quaternion desiredRotation = Quaternion.AngleAxis(m_MovementDirection.x * -m_Tilt, transform.up);
			float rotationStep = Time.deltaTime * m_AngularSpeed;
			transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRotation, rotationStep);
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