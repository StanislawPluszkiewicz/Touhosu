﻿using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class HomingBullet : Bullet
{
	[Header("Homing Bullet - readonly")]
	[ReadOnly] public Transform m_Target;


	public void Init(Vector3 shootDirection, Transform target, MovementPattern pattern = null)
	{
		Debug.Log("Shooting homing bullet ");
		Init(shootDirection, pattern);
		m_Target = target;
	}
	public override Vector3 GetShootDirection(float timeSinceBirth)
	{
		Vector3 v = base.GetShootDirection(timeSinceBirth);
		return (v + (m_Target.position - transform.position)).normalized;
	}
	public override Vector3 SetCurrentVelocity(float timeSinceBirth)
	{
		return GetShootDirection(timeSinceBirth) * m_Speed * Time.deltaTime;
	}

}