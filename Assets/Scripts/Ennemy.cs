using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class Ennemy : Actor
	{
		public BezierCurve movementCurve;
		public BezierSpline movementSpline;
		private bool useSpline = false;
		private float exploredPath = 0.0f;

		protected override void Awake()
		{
			if (movementCurve == null && movementSpline == null)
			{
				Debug.LogError("Make sure to set at least one movement pattern", this);
			}
			else if (movementCurve == null)
			{
				useSpline = true;
			}
		}

		protected override void GetMoveInput()
		{
			if (useSpline)
			{
				m_MovementDirection = movementSpline.GetDirection(exploredPath);
			}
			else
			{
				m_MovementDirection = movementCurve.GetDirection(exploredPath);
			}
			exploredPath += Time.deltaTime;
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
