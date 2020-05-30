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

		public void Awake()
		{
			m_Shooters = GetComponentsInChildren<Shooter>();
			if (m_Shooters.Length == 0) Debug.LogError("Weapon has no Shooter!", this);
		}

		public void Shoot()
		{
			foreach (Shooter instance in m_Shooters)
			{
				instance.Shoot(m_Target);
			}
		}

		public void SetTarget(Transform t)
		{
			m_Target = t;
		}
	}
}