using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class HomingBullet : Bullet
{
	public override IEnumerator Create(Vector3 shootDirection, MovementPattern pattern)
	{
		_rb.velocity = shootDirection * m_Speed;
		// TODO remove angular velocity
		_rb.angularVelocity = shootDirection * m_Speed;
		_rb.useGravity = false;
		StartCoroutine(Travel(pattern));
		yield return null;
	}
	public override IEnumerator Travel(MovementPattern pattern)
	{
		float birthTime = Time.time;

		while (true)
		{
			float t = Time.time - birthTime;
			float tDecimal = t - (float)Math.Truncate(t);
			_rb.velocity = pattern.GetDirection(tDecimal) * m_Speed;
			// Debug.Log("[" + tDecimal + "]: " + pattern.GetDirection(t));
			yield return null;
		}
	}

}
