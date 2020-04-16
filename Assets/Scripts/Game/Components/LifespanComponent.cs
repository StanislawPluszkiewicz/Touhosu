using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace Game.Components
{
    [GenerateAuthoringComponent]
    public struct LifespanComponent : IComponentData
    {
        public float m_lifespan;
    }
}

