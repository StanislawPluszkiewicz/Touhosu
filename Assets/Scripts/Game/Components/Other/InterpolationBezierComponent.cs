
using Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unity.Entities;
using Unity.Mathematics;

namespace Game.Components
{
    [GenerateAuthoringComponent]
    public struct InterpolationBezierComponent : IComponentData
    {

        public float3 m_StartParam;

        public float3 m_EndParam;

    }
}
