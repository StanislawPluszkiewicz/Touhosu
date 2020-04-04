using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;


namespace Components
{
    public struct InputMovementComponent : IComponentData
	{
        public float m_Vertical;

        public float m_Horizontal;

        public bool m_SlowDown;

        public float m_Speed;
    }
}