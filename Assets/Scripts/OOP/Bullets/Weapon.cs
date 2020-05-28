using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class Weapon : SerializedMonoBehaviour
	{
		[SerializeField] List<Shooter> m_Shooters;
		public Transform m_Target;

		public void Shoot()
		{
			foreach (Shooter prefab in m_Shooters)
			{
				prefab.Shoot(m_Target);
			}
		}
	}
}