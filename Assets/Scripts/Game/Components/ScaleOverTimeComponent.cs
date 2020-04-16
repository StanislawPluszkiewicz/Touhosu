
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace Game.Components
{
    [GenerateAuthoringComponent]
    public struct ScaleOverTimeComponent : IComponentData
    {


        public float3 m_NewScale;

        public float m_StartTime;

        public float m_Time;

        //public AnimationCurve m_SpeedOverTime;

    }
}