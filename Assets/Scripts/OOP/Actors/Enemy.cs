using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class Enemy : Actor
	{
		public BezierSpline m_MovementMotor;
		[SerializeField] float m_TimeForBezier;
		private PlayerController m_Player;


		protected override void Awake()
		{
			base.Awake();
			m_Player = FindObjectOfType<PlayerController>();
			if (m_Player == null) Debug.LogError("No player found in scene", this);
		}
		protected override Transform FindTarget()
		{
			return m_Player.transform;
		}


		protected override Vector3 GetMoveInput()
		{
			return m_MovementMotor.GetFinalVelocity(Time.time) / m_TimeForBezier;
		}
		protected override bool GetShootInput()
		{
			return true;
		}

		private void OnDrawGizmosSelected()
		{
			Gizmos.color = Color.magenta;
			Gizmos.DrawLine(transform.position, transform.position + m_Velocity / m_TimeForBezier);
		}
	}
}
