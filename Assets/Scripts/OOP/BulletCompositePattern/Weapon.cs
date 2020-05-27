using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : SerializedMonoBehaviour
{
	[SerializeField] float m_FireRate;
	float m_NextFireTime;
	
	// [SerializeField] AnimationClip m_ShootAnimation;
	[SerializeField] GameObject m_FirePositionTransform;
	[SerializeField] Bullet m_BulletPrefab;
	[SerializeField] float m_ShootVelocity;
	[SerializeField] public Motor m_ShootPattern;
	public Transform m_Target;


	private Vector3 GetFirePosition()
	{
		return (m_FirePositionTransform) ? m_FirePositionTransform.transform.position : transform.position;
	}
	private float GetBulletLifeTime()
	{ return m_BulletPrefab.m_LifeTime; }

	public void CreateDefaultShootPattern()
	{
		Motor prefab = Resources.Load<Motor>("movement_pattern_default");
		m_ShootPattern = Instantiate(prefab, transform.position, Quaternion.identity, transform) as Motor;
	}

	public void Shoot()
	{
		if (CanShoot())
		{
			dynamic bullet = m_BulletPrefab.Instantiate(GetFirePosition(), transform);

			if (bullet is HomingBullet)
				(bullet as HomingBullet).Init(transform.up, m_Target, m_ShootPattern);
			else if (bullet is Bullet)
				(bullet as Bullet).Init(transform.up, m_ShootPattern);
			StartCoroutine(bullet.Travel());

			m_NextFireTime = Time.time + m_FireRate;
		}
	}
	public bool CanShoot()
	{
		return Time.time > m_NextFireTime;
	}
}
