using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;


public class VectorialMovementComponent : IComponentData
{

    public float m_Speed;

    public float3 m_Acceleration;

    public float3 m_Direction;

}