using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class HomingBullet : Bullet
{
	[Header("Homing Bullet - readonly")]
	[ReadOnly] public Transform m_Target;


	public void Init(Vector3 shootDirection, Transform target, Motor pattern = null)
	{
		Init(shootDirection, pattern);
		m_Target = target;
	}
	public override Vector3 GetShootDirection(float timeSinceBirth)
	{
		Vector3 v = base.GetShootDirection(timeSinceBirth);
		return (v + (m_Target.position - transform.position)).normalized;
	}
	public override Vector3 GetVelocity(float timeSinceBirth)
	{
		return GetShootDirection(timeSinceBirth) * m_Speed * Time.deltaTime;
	}

}
