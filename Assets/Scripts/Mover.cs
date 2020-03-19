using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
	public float m_Speed;

	private Rigidbody rb;

	private void Start()
	{
		rb.velocity = transform.forward * m_Speed;
	}
}
