using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;


namespace Game
{
	public class OnCollisionExitDestroyBullet : MonoBehaviour
	{

		[SerializeField] private bool m_OnCollision, m_OnTrigger;
		private void OnCollisionExit(Collision c)
		{
			if (m_OnCollision) DESTROYTHEMALL(c.gameObject);
		}

		private void OnTriggerExit(Collider c)
		{
			if (m_OnTrigger) DESTROYTHEMALL(c.gameObject);
		}

		private void DESTROYTHEMALL(GameObject go)
		{
			Bullet b = go.GetComponentInParent<Bullet>() as Bullet;
			if (b)
			{
				Helper.Destroy(b.gameObject);
			}
			Actor a = go.GetComponentInParent<Actor>() as Actor;
			if (a)
			{
				StartCoroutine(a.Destroy());
			}
		}
	}
}
