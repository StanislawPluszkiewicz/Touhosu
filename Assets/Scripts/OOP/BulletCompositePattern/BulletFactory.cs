using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class BulletFactory : MonoBehaviour
{
	public static Bullet normalPrefab;
	public static HomingBullet homingPrefab;


	public static IEnumerator CreateNormal(
		Transform parent, Vector3 spawnPosition, Vector3 shootDirection, 
		float bSpeed, float bLifeTime, MovementPattern pattern = null)
	{
		Bullet instance = Instantiate(normalPrefab, spawnPosition, Quaternion.identity, parent);
		instance.m_Speed = bSpeed;
		instance.m_LifeTime = bLifeTime;
		instance._rb.velocity = shootDirection * instance.m_Speed;
		// TODO remove angular velocity
		instance._rb.angularVelocity = shootDirection * instance.m_Speed;
		instance._rb.useGravity = false;
		if (pattern)
			instance.StartCoroutine(instance.Travel(pattern));
		else
			instance.StartCoroutine(instance.Travel());
		yield return null;
	}

}
