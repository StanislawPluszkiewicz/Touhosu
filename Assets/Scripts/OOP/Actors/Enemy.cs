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
		
		protected override Vector3 GetMoveInput()
		{
			return m_MovementMotor.GetFinalVelocity(Time.time) / m_TimeForBezier;
		}
		protected override bool GetShootInput()
		{
			return true;
		}
		protected override LayerMask GetProjectileLayerMask()
		{
			return LayerMask.NameToLayer("Enemy Bullet");
		}

		private void OnDrawGizmosSelected()
		{
			Gizmos.color = Color.magenta;
			Gizmos.DrawLine(transform.position, transform.position + m_Velocity / m_TimeForBezier);
		}
	}
}
