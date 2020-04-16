using Game.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

namespace Game.Systems
{
	public class InputShootSystem : ComponentSystem
	{

		protected override void OnUpdate()
		{
			Entities.ForEach((ref InputShootComponent inputComponent, ref ShootComponent shootComponent) =>
			{
				if (Input.GetKeyDown(Game.KeyBindings.Shoot))
				{
					shootComponent.m_DoShoot = true;
				}
			});
		}
	}
}