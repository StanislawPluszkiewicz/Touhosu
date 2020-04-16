
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
	public class InputMoveSystem : ComponentSystem
	{

		protected override void OnUpdate()
		{
			Entities.ForEach((ref InputMovementComponent movementComponent) =>
			{
				movementComponent.m_SlowDown = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
			});

			if (Input.GetAxis("Vertical") != 0f)
			{
				float verticalMovement = Input.GetAxis("Vertical") * Time.DeltaTime;
				Entities.ForEach((ref Translation translation, ref InputMovementComponent movementComponent) =>
				{
					translation.Value.y += movementComponent.m_SlowDown ? verticalMovement * movementComponent.m_Speed / 2 : verticalMovement * movementComponent.m_Speed;
				});
			}
			if (Input.GetAxis("Horizontal") != 0f)
			{
				float horizontalMovement = Input.GetAxis("Horizontal") * Time.DeltaTime;
				Entities.ForEach((ref Translation translation, ref InputMovementComponent movementComponent) =>
				{
					translation.Value.x += movementComponent.m_SlowDown ? horizontalMovement * movementComponent.m_Speed / 2 : horizontalMovement * movementComponent.m_Speed;
				});
			}
		}

	}
}
