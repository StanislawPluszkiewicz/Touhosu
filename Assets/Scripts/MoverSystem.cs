using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;

public class MoverSystem : ComponentSystem
{
	protected override void OnUpdate()
	{
		Entities.ForEach((ref Translation translation, ref MoveSpeedComponent moveSpeedComponent) => {
			translation.Value.y += moveSpeedComponent.moveSpeed * Time.DeltaTime;
			if (translation.Value.y > 5f || translation.Value.y < -5f)
			{
				moveSpeedComponent.moveSpeed *= -1;
			}
		});
	}
}
