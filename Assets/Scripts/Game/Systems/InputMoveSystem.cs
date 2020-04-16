
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
    [BurstCompile]
    public class InputMoveSystem : ComponentSystem
    {
        protected override void OnUpdate()
        {
            float verticalMovement = Input.GetAxisRaw("Vertical");
            float horizontalMovement = Input.GetAxisRaw("Horizontal");
            bool isSlowing = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

            Entities.ForEach((ref MovementComponent movementComponent, ref InputMovementComponent inputMovementComponent) =>
            {
                movementComponent.m_SlowDown = isSlowing;
                movementComponent.m_Vertical = verticalMovement;
                movementComponent.m_Horizontal = horizontalMovement;

            });

        }

    }

}