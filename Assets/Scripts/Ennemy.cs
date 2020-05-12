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

		protected override void GetMoveInput()
		{
			m_MovementDirection = new Vector3(moveHorizontal, moveVertical, 0);
		}
		protected override void GetShootInput()
		{
			m_DoShoot = (Input.GetKey(Game.KeyBindings.Shoot));
		}

	}
}
