using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class PlayerController : Actor
	{
		[SerializeField] protected float m_Speed;
		[Title("Movement Restriction")]
		[SerializeField] private bool m_ShowBoundaryGizmo;


		protected override Transform FindTarget()
		{
			Vector3 mousePos = Input.mousePosition;
			mousePos.z = Helper.ShipHeights;
			Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
			// Debug.Log(worldPosition);

			// set closest enemy to worldpos
			return null;
		}

		protected override Vector3 GetMoveInput()
		{
			float moveHorizontal = Input.GetAxisRaw("Horizontal");
			float moveVertical = Input.GetAxisRaw("Vertical");
			return new Vector3(moveHorizontal, moveVertical, 0) * m_Speed * Time.deltaTime;
		}
		protected override bool GetShootInput()
		{
			return (Input.GetKey(Game.KeyBindings.Shoot));
		}

		private void OnDrawGizmos()
		{
			if (m_ShowBoundaryGizmo)
				Boundary.ShowGizmos(Color.yellow);
		}
	}

}
