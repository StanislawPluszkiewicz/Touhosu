﻿using Sirenix.OdinInspector;
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
	[SerializeField] public MovementPattern m_ShootPattern;



	private Vector3 GetFirePosition()
	{
		return (m_FirePositionTransform) ? m_FirePositionTransform.transform.position : transform.position;
	}
	private float GetBulletLifeTime()
	{ return m_BulletPrefab.m_LifeTime; }

	public void CreateDefaultShootPattern()
	{
		MovementPattern prefab = Resources.Load<MovementPattern>("movement_pattern_default");
		m_ShootPattern = Instantiate(prefab, transform.position, Quaternion.identity, transform) as MovementPattern;
	}

	public void Shoot()
	{
		if (CanShoot())
		{
			Bullet p = Instantiate(m_BulletPrefab, GetFirePosition(), Quaternion.identity) as Bullet;
			StartCoroutine(p.Create(transform.up, m_ShootPattern));
			m_NextFireTime = Time.time + m_FireRate;
		}
	}
	public bool CanShoot()
	{
		return Time.time > m_NextFireTime;
	}
}
