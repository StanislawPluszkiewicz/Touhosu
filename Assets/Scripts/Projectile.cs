using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	[SerializeField] public float m_AliveTime = 10f;
	[SerializeField] public float m_Speed = 10f;

	Rigidbody _rb;

	public void Awake()
	{
		_rb = GetComponent<Rigidbody>();
		if (_rb == null)
		{
			_rb = gameObject.AddComponent<Rigidbody>();
		}
	}
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

	public IEnumerator Create(Vector3 shootDirection, BezierCurve curve)
	{
		_rb.velocity = shootDirection * m_Speed;
		// TODO remove angular velocity
		_rb.angularVelocity = shootDirection * m_Speed;
		_rb.useGravity = false;
		StartCoroutine(Travel(curve));
		yield return null;
	}

	public IEnumerator Travel(BezierCurve curve)
	{
		float birthTime = Time.time;

		while (true)
		{
			float t = Time.time - birthTime;
			float tDecimal = t - (float)Math.Truncate(t);
			_rb.velocity = curve.GetDirection(tDecimal) * m_Speed;
			Debug.Log("[" + tDecimal + "]: " + curve.GetDirection(t));
			yield return null;
		}
	}
}
