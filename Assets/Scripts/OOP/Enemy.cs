using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class Enemy : Actor
	{
		public Motor m_Motor;

		public override Vector3 GetVelocity()
		{
			return m_Motor.GetFinalVelocity(m_TimeSinceBirth);
		}
		protected override void GetMoveInput()
		{
			m_MovementDirection = m_Motor.GetFinalVelocity(m_TimeSinceBirth);
		}
		protected override void GetShootInput()
		{
			m_DoShoot = (Input.GetKey(Game.KeyBindings.Shoot));
		}

		private void OnDrawGizmosSelected()
		{
			Gizmos.color = Color.magenta;
			Gizmos.DrawLine(transform.position, transform.position + m_MovementDirection * m_Speed);
		}
	}
}
