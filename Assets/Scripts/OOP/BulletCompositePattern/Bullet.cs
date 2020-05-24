using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class Bullet : Composite
{
	public float m_LifeTime = 10f;
	public float m_Speed = 10f;

	public Rigidbody _rb;

	#region Events
	delegate void Event();
	Event onBirth, onDeath;
	private Event OnBirth { get => onBirth; set => onBirth = value; }
	private Event OnDeath { get => onDeath; set => onDeath = value; }
	#endregion

	#region Memebers Getters and Setters
	float GetSpeed()
	{
		if (FindObjectOfType<CameraMovement>() != null)
			return (FindObjectOfType<CameraMovement>().cameraSpeed + m_Speed) * Time.deltaTime;
		else
			return 0f;
	}
	#endregion

	#region Translation
	public virtual IEnumerator Travel(MovementPattern pattern)
	{
		float birthTime = Time.time;

		while (true)
		{
			float t = Time.time - birthTime;
			float tDecimal = t - (float)Math.Truncate(t);
			_rb.velocity = pattern.GetDirection(tDecimal) * m_Speed;
			yield return null;
		}
	}
	public virtual IEnumerator Travel()
	{
		float birthTime = Time.time;

		while (true)
		{
			float t = Time.time - birthTime;
			float tDecimal = t - (float)Math.Truncate(t);
			_rb.velocity = transform.up * m_Speed;
			yield return null;
		}
	}
	#endregion

	#region Unity Events
	private void Awake()
	{
		_rb = GetComponent<Rigidbody>();
		if (_rb == null)
		{
			_rb = gameObject.AddComponent<Rigidbody>();
		}
	}
	private void Start()
	{
		Destroy(gameObject, m_LifeTime);
		OnBirth();
	}
	private void Update()
	{
	}
	private void OnDestroy()
	{
		OnDeath();
	}
	#endregion
}
