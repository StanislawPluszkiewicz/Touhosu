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
	public float m_Speed = 10f;

	[Header("Bullet - readonly")]
	[ReadOnly] public Vector3 m_ShootDirection; // Direction towards which the bullet was originally shot
	[ReadOnly] public Motor m_Pattern;

	[HideInInspector] public Rigidbody _rb;

	#region Events
	delegate void Event();
	Event onBirth, onDeath;
	private Event OnBirth { get => onBirth; set => onBirth = value; }
	private Event OnDeath { get => onDeath; set => onDeath = value; }
	#endregion

	#region Members Getters and Setters
	float GetSpeed()
	{
		if (FindObjectOfType<CameraMovement>() != null)
			return (FindObjectOfType<CameraMovement>().cameraSpeed + m_Speed) * Time.deltaTime;
		else
			return 0f;
	}
	#endregion

	#region Creation
	public virtual Bullet Instantiate(Vector3 position, Transform parent)
	{
		return Instantiate(this, position, Quaternion.identity);
	}
	public void Init(Vector3 shootDirection, Motor pattern = null)
	{
		m_Pattern = pattern;
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
		return (m_Pattern == null) ? m_ShootDirection : m_Pattern.GetVelocity(GetDecimalTime(t));
	}
	public virtual Vector3 GetVelocity(float t)
	{
		return GetShootDirection(t) /** m_Speed */ * Time.deltaTime;
	}
	public IEnumerator Travel()
	{
		float birthTime = Time.time;

		while (true)
		{
			float t = Time.time - birthTime;
			transform.position += GetVelocity(t) * 2;
			_rb.angularVelocity = m_ShootDirection * m_Speed;
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
