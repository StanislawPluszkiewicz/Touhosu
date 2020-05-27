using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class Bullet : Composite
{
	[Header("Bullet")]
	public float m_LifeTime = 10f;

	[Header("Bullet - readonly")]
	[ReadOnly] public Vector3 m_ShootDirection; // Direction towards which the bullet was originally shot
	[ReadOnly] public Motor m_Motor;

	[HideInInspector] public Rigidbody _rb;

	#region Events
	delegate void Event();
	Event onBirth, onDeath;
	private Event OnBirth { get => onBirth; set => onBirth = value; }
	private Event OnDeath { get => onDeath; set => onDeath = value; }
	#endregion
	
	#region Creation
	public virtual Bullet Instantiate(Vector3 position, Transform parent)
	{
		return Instantiate(this, position, Quaternion.identity);
	}
	public void Init(Vector3 shootDirection, Motor pattern = null)
	{
		m_Motor = pattern;
		m_ShootDirection = shootDirection;
	}
	#endregion

	#region Translation
	protected float GetDecimalTime(float t)
	{
		return t - (float)Math.Truncate(t);
	}
	public virtual Vector3 GetShootDirection(float t)
	{
		return (m_Motor == null) ? m_ShootDirection : m_Motor.GetVelocity(m_Motor.GetDecimalTime(t));
	}
	public virtual Vector3 GetVelocity(float t)
	{
		return GetShootDirection(t) * Time.deltaTime;
	}
	public IEnumerator Travel()
	{
		float birthTime = Time.time;

		while (true)
		{
			float t = Time.time - birthTime;
			transform.position += GetVelocity(t); // dont ask why
			_rb.angularVelocity = m_ShootDirection;
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
		_rb.useGravity = false;
	}
	private void Start()
	{
		Destroy(gameObject, m_LifeTime);
		OnBirth?.Invoke();
	}
	private void Update()
	{
	}
	private void OnDestroy()
	{
		OnDeath?.Invoke();
	}
	#endregion
}
