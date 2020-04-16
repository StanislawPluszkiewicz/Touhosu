using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace Components
{
    public struct LifespanComponent : IComponentData
    {
        public float m_lifespan;
    }
}

