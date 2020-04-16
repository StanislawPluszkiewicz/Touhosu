
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
	public class ShootSystem : ComponentSystem
	{
		protected override void OnUpdate()
		{
			Entities.ForEach((ref ShootComponent c) =>
			{
				if (c.m_DoShoot)
				{
					c.m_DoShoot = false;
				}
			});
		}
	}
}