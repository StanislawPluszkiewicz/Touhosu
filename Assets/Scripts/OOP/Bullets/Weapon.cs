using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class Weapon : SerializedMonoBehaviour
	{
		[SerializeField] Shooter[] m_Shooters;
		public Transform m_Target;

		private LayerMask m_ProjectileLayer;

		public LayerMask ProjectileLayer { get => m_ProjectileLayer; set => m_ProjectileLayer = value; }

		public void Awake()
		{
			m_Shooters = GetComponentsInChildren<Shooter>();
			if (m_Shooters.Length == 0) Debug.LogError("Weapon has no Shooter!", this);
		}

		public void Shoot()
		{
			foreach (Shooter instance in m_Shooters)
			{
				instance.Shoot(ProjectileLayer, m_Target);
			}
		}

		public IEnumerator Destroy()
		{
			foreach (Shooter instance in m_Shooters)
			{
				StartCoroutine(instance.Destroy());
			}
			yield return null;
		}
	}
}