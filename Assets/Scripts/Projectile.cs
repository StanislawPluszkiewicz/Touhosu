using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	[SerializeField] float m_AliveTime = 10f;
	[SerializeField] float m_Speed = 10f;
	Rigidbody rb;

	public void Start()
	{
		Destroy(gameObject, m_AliveTime);
		rb = GetComponent<Rigidbody>();
	}

	public void Update()
	{
		rb.velocity = transform.up * m_Speed * Time.deltaTime;
	}
}
