
using Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unity.Entities;
using UnityEngine;

public class InputMoveSystem : ComponentSystem {


    protected override void OnUpdate()
    {
        if(Input.GetAxis("Vertical") != 0f)
        {
            float verticalMovement = Input.GetAxis("Vertical");
            Entities.ForEach((ref InputMovementComponent movementComponent) =>
            {
                movementComponent.m_Vertical += verticalMovement * Time.DeltaTime;
            });
        }
        if (Input.GetAxis("Horizontal") != 0f)
        {
            float horizontalMovement = Input.GetAxis("Horizontal");
            Entities.ForEach((ref InputMovementComponent movementComponent) =>
            {
                movementComponent.m_Horizontal += horizontalMovement * Time.DeltaTime;
            });
        }
    }

}