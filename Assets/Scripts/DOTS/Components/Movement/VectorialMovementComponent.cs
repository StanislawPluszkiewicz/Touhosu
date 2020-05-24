using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

namespace Game.Components
{
    public class VectorialMovementComponent : IComponentData
    {
        public float m_Speed;
        public float m_Acceleration;
        public float3 m_Direction;

    }
}
