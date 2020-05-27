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
	[MinValue(0.1)] public float m_Homingness;


	public void Init(Vector3 shootDirection, Transform target, Motor pattern = null)
	{
		Init(shootDirection, pattern);
		m_Target = target;
	}
	public override Vector3 GetVelocity(float t)
	{
		return (base.GetVelocity(t) + (m_Target.position - transform.position)) 
			/ m_Homingness;
	}
}
