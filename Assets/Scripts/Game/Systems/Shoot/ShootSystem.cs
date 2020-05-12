
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
	[UpdateAfter(typeof(InputShootSystem))]
	[UpdateAfter(typeof(AutomaticShootSystem))]
	public class ShootSystem : ComponentSystem
	{
		protected override void OnUpdate()
		{
			float deltaTime = Time.DeltaTime;
			double currentTime = Time.ElapsedTime;
			Entities.ForEach((ref ShootComponent c, ref Translation translation) =>
			{
				if (c.m_DoShoot)
				{
					Debug.Log("Shooting");
					// GameObject.Instantiate(BulletManager.Get(c.m_BulletId), translation.Value, Quaternion.identity, null);
				}
			});
		}
	}
}