﻿using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class PlayerController : Actor
	{
		[Title("Movement Restriction")]
		[SerializeField] private bool m_ShowBoundaryGizmo;

		protected override void GetMoveInput()
		{
			float moveHorizontal = Input.GetAxisRaw("Horizontal");
			float moveVertical = Input.GetAxisRaw("Vertical");
			m_MovementDirection = new Vector3(moveHorizontal, moveVertical, 0);
		}
		protected override void GetShootInput()
		{
			m_DoShoot = (Input.GetKey(Game.KeyBindings.Shoot));
		}

		private void OnDrawGizmos()
		{
			if (m_ShowBoundaryGizmo)
				Boundary.ShowGizmos(Color.yellow);
		}
	}

}