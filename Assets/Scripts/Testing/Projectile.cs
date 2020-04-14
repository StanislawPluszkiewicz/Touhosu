using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	[SerializeField] float m_AliveTime = 10f;
	[SerializeField] float m_Speed = 10f;

	public void Start()
	{
		Destroy(gameObject, m_AliveTime);

	}

	float GetSpeed()
	{
		if (FindObjectOfType<CameraMovement>() != null)
			return (FindObjectOfType<CameraMovement>().cameraSpeed + m_Speed) * Time.deltaTime;
		else
			return 0f;
	}

	public void Update()
	{
		transform.Translate(transform.up * GetSpeed());
	}
}
