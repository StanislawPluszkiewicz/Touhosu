using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	[SerializeField] GameObject m_Spawn;
	[SerializeField] Projectile m_Projectile;
	[SerializeField] float m_FireRate;
	float m_NextFire;



	public void Shoot()
	{
		Debug.Log("Shooting");
		if (CanShoot())
		{
			Projectile p = Instantiate(m_Projectile, m_Spawn.transform.position, Quaternion.identity) as Projectile;
			// p.transform.LookAt(transform.up);
			m_NextFire = Time.time + m_FireRate;
		}
	}
	public bool CanShoot()
	{
		return Time.time > m_NextFire;
	}
}
