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
	[SerializeField] BezierCurve m_BezierCurve;
	float m_NextFire;
	
	public void Shoot()
	{
		if (CanShoot())
		{
			Vector3 spawnPosition = (m_Spawn) ? m_Spawn.transform.position : transform.position;
			Projectile p = Instantiate(m_Projectile, spawnPosition, Quaternion.identity) as Projectile;
			StartCoroutine(p.Create(transform.up, m_BezierCurve));
			m_NextFire = Time.time + m_FireRate;
		}
	}
	public bool CanShoot()
	{
		return Time.time > m_NextFire;
	}
}
