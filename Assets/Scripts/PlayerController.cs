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
		public float xMin, xMax, zMin, zMax;
	}

	public class PlayerController : MonoBehaviour
	{
		[Title("Movement")]
		public float m_Speed;
		public float m_Tilt;
		public Boundary m_Boundary;

		[Title("Shooting")]
		public GameObject m_ProjectilesParent;
		public GameObject m_ShotPrefab;
		public Transform m_ShotSpawn;
		public float m_FireRate;
		float m_NextFire;

		Rigidbody rb;

		void Awake()
		{
			rb = GetComponent<Rigidbody>();
			m_ProjectilesParent = GameObject.Find("Projectiles");
			if (m_ProjectilesParent == null)
			{
				m_ProjectilesParent = new GameObject("Projectiles");
			}
		}

		void Update()
		{
			if (Input.GetButton("Fire1") && Time.time > m_NextFire)
			{
				m_NextFire = Time.time + m_FireRate;
				Instantiate(m_ShotPrefab, m_ShotSpawn.position, m_ShotSpawn.rotation, m_ProjectilesParent.transform);
			}
		}

		void FixedUpdate()
		{
			float moveHorizontal = Input.GetAxis("Horizontal");
			float moveVertical = Input.GetAxis("Vertical");

			Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
			rb.velocity = movement * m_Speed * Time.deltaTime;

			rb.position = new Vector3
			(
				Mathf.Clamp(rb.position.x, m_Boundary.xMin, m_Boundary.xMax),
				0.0f,
				Mathf.Clamp(rb.position.z, m_Boundary.zMin, m_Boundary.zMax)
			);

			rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -m_Tilt);
		}

	}
}
