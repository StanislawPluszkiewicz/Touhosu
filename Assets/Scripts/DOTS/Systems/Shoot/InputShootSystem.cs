using Game.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;
using Unity.Burst;

namespace Game.Systems
{
	public class InputShootSystem : ComponentSystem
	{
		protected override void OnUpdate()
		{
			if (Input.GetKeyDown(Game.KeyBindings.Shoot))
			{
				Entities.ForEach((ref InputShootComponent inputComponent, ref ShootComponent shootComponent) =>
				{
					shootComponent.m_DoShoot = true;
				});
			}

			if (Input.GetKeyUp(Game.KeyBindings.Shoot))
			{
				Entities.ForEach((ref InputShootComponent inputComponent, ref ShootComponent shootComponent) =>
				{
					shootComponent.m_DoShoot = false;
				});
			}
		}
	}
}