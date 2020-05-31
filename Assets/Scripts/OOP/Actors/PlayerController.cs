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
		[SerializeField] GameManager gm;
		public override void TakeDamage(float dmg)
		{
			HP -= dmg;
			if(HP < 0)
			{
				gm.GameOver(false);
				HP = DefaultHP;
			}
		}

		protected override Vector3 GetMoveInput(float timeSinceBirth)
		{
			float moveHorizontal = Input.GetAxisRaw("Horizontal");
			float moveVertical = Input.GetAxisRaw("Vertical");
			return new Vector3(moveHorizontal, moveVertical, 0) * m_Speed * Time.deltaTime;
		}
		protected override bool GetSlowDownTimeInput()
		{
			return Input.GetKey(KeyCode.LeftShift);
		}
		protected override bool GetShootInput()
		{
			return (Input.GetKey(Game.KeyBindings.Shoot));
		}
		protected override LayerMask GetProjectileLayerMask()
		{
			return LayerMask.NameToLayer("Player bullet");
		}
		private void OnDrawGizmos()
		{
			if (m_ShowBoundaryGizmo)
				Boundary.ShowGizmos(Color.yellow);
		}
	}

}
