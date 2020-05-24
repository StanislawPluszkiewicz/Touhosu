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
	[ReadOnly] public MovementPattern m_Pattern;
	[ReadOnly] public Vector3 m_CurrentVelocity;

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
	public void Init(Vector3 shootDirection, MovementPattern pattern = null)
	{
		m_Pattern = pattern;
		m_ShootDirection = shootDirection;
	}
	#endregion

	#region Translation
	protected float GetDecimalTimeSinceBirth(float timeSinceBirth)
	{
		return timeSinceBirth - (float)Math.Truncate(timeSinceBirth);
	}
	public virtual Vector3 GetShootDirection(float timeSinceBirth)
	{
		float tDecimal = GetDecimalTimeSinceBirth(timeSinceBirth);
		return (m_Pattern == null) ? m_ShootDirection : m_Pattern.GetDirection(tDecimal);
	}
	public virtual Vector3 SetCurrentVelocity(float timeSinceBirth)
	{
		return GetShootDirection(timeSinceBirth) * m_Speed * Time.deltaTime;
	}
	public IEnumerator Travel()
	{
		float birthTime = Time.time;

		while (true)
		{
			float timeSinceBirth = Time.time - birthTime;
			m_CurrentVelocity = SetCurrentVelocity(timeSinceBirth);
			transform.position += m_CurrentVelocity;
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
