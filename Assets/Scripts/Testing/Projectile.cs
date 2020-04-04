using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
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
		return (FindObjectOfType<CameraMovement>().cameraSpeed + m_Speed) * Time.deltaTime;
	}

	public void Update()
	{
		transform.Translate(transform.up * GetSpeed());
	}
}
