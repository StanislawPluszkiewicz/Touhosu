using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	[System.Serializable]
	public class Boundary
	{
		public float xMin, xMax, yMin, yMax;
	}
	public class PlayerController : MonoBehaviour
	{
		[Title("Movement")]
		public float m_Height;
		public float m_Speed;
		public float m_Tilt;
		[Title("Movement Restriction")]
		public Boundary m_Boundary;
		[SerializeField] private bool m_ShowBoundaryGizmo;


		[Title("Shooting")]
		Weapon[] m_Weapons;



		Rigidbody rb;
		CameraMovement cm;

		void Awake()
		{
			rb = GetComponent<Rigidbody>();
			m_Weapons = transform.GetComponentsInChildren<Weapon>();
		}

		void Start()
		{
			cm = FindObjectOfType<CameraMovement>();	
		}

		void Update()
		{
			if (Input.GetButton("Fire1") && m_Weapons != null)
			{
				foreach (Weapon weapon in m_Weapons)
				{
					weapon.Shoot();
				}
			}
		}

		void FixedUpdate()
		{
			Move();
		}

		private void Move()
		{
			float moveHorizontal = Input.GetAxis("Horizontal");
			float moveVertical = Input.GetAxis("Vertical");

			Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0);
			rb.velocity = movement * m_Speed;

			transform.localPosition = new Vector3
			(
				Mathf.Clamp(transform.localPosition.x, m_Boundary.xMin, m_Boundary.xMax),
				Mathf.Clamp(transform.localPosition.y, m_Boundary.yMin, m_Boundary.yMax),
				m_Height
			);

			rb.rotation = Quaternion.Euler(0.0f, Mathf.Lerp(rb.rotation.y, moveHorizontal * -m_Tilt, Time.deltaTime), 0.0f);
		}

		private void OnDrawGizmos()
		{
			if (cm != null && m_ShowBoundaryGizmo)
			{
				Gizmos.color = Color.yellow;
				Vector3 upLeft		= cm.transform.position + (Vector3.right * m_Boundary.xMin) + (Vector3.up * m_Boundary.yMax);
				Vector3 upRight		= cm.transform.position + (Vector3.right * m_Boundary.xMax) + (Vector3.up * m_Boundary.yMax);
				Vector3 downLeft	= cm.transform.position + (Vector3.right * m_Boundary.xMin) + (Vector3.up * m_Boundary.yMin);
				Vector3 downRight	= cm.transform.position + (Vector3.right * m_Boundary.xMax) + (Vector3.up * m_Boundary.yMin);

				Gizmos.DrawLine(upLeft, upRight);
				Gizmos.DrawLine(upRight, downRight);
				Gizmos.DrawLine(downRight, downLeft);
				Gizmos.DrawLine(downLeft, upLeft);
			}
		}
	}

}
