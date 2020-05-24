﻿using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class Ennemy : Actor
	{
		public MovementPattern movementPattern;
		private float exploredPath = 0.0f;

		protected override void GetMoveInput()
		{
			m_MovementDirection = movementPattern.GetDirection(exploredPath);
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