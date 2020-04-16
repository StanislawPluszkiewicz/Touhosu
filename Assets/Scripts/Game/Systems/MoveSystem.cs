
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
    public class MoveSystem : ComponentSystem
    {

        protected override void OnUpdate()
        {
            Entities.ForEach((ref Translation translation, ref MovementComponent movementComponent) =>
            {
                bool isSlowing = movementComponent.m_SlowDown;
                float speed = movementComponent.m_Speed;
                float xMovement = movementComponent.m_Horizontal * Time.DeltaTime * speed;
                float yMovement = movementComponent.m_Vertical * Time.DeltaTime * speed;
                if (isSlowing)
                {
                    xMovement /= 2;
                    yMovement /= 2;
                }

                translation.Value.x += xMovement;
                translation.Value.y += yMovement;
            });

        }
    }
}