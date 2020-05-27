using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class Enemy : Actor
	{
		public MovementPattern movementPattern;
		private float exploredPath = 0.0f;
		public bool RotateMovement = true;

		protected override void GetMoveInput()
		{
			m_MovementDirection = movementPattern.GetVelocity(exploredPath);
			exploredPath += Time.deltaTime;

			if(RotateMovement)
				transform.eulerAngles = new Vector3(0, 180f, 360f - Vector3.Angle(Vector3.up, m_MovementDirection));
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
