using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class Enemy : Actor
	{
		[Header("Bezier translation")]
		public BezierSpline m_MovementMotor;
		[SerializeField] float m_TimeFactor;
		[SerializeField] float m_Amplitude = 1.0f;

		float m_PatternProgress = 0;

		protected override bool GetSlowDownTimeInput() => false;

		protected override Vector3 GetMoveInput(float timeSinceBirth)
		{
			// Debug.Log("m_BirthTime(" + m_BirthTime + ") :" + m_MovementMotor.GetVelocity(m_BirthTime));
			// Debug.Log("Time.time(" + Time.time + ") :" + m_MovementMotor.GetVelocity(Time.time));
			// Debug.Log("Time.deltaTime(" + Time.deltaTime + ") :" + m_MovementMotor.GetVelocity(Time.deltaTime));
			// Debug.Log("t(" + t + ") :" + m_MovementMotor.GetVelocity(t));
			// Debug.Log("timeSinceBirth(" + timeSinceBirth + ") :" + m_MovementMotor.GetVelocity(timeSinceBirth));
			// float factor = m_TranslateSpeed * Time.deltaTime / m_TimeForBezier;
			// Debug.Log("t   :" + timeSinceBirth);
			// Debug.Log("t :" + m_MovementMotor.GetDecimalTime(timeSinceBirth) + " # " + m_MovementMotor.GetFinalVelocity(timeSinceBirth * m_TimeFactor).normalized * m_Amplitude);

			return m_MovementMotor.GetFinalVelocity(timeSinceBirth * m_TimeFactor).normalized * m_Amplitude;
		}
		protected override bool GetShootInput()
		{
			return true;
		}
		protected override LayerMask GetProjectileLayerMask()
		{
			return LayerMask.NameToLayer("Enemy bullet");
		}
		private void OnDrawGizmosSelected()
		{
			Gizmos.color = Color.magenta;
			Gizmos.DrawLine(transform.position, transform.position + m_Velocity);
		}

		public override void TakeDamage(float dmg)
		{
			HP -= dmg;
			if (HP <= 0)
				Destroy();

		}
	}
}
