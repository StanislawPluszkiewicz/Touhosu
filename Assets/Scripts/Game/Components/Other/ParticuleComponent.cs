
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unity.Entities;

namespace Game.Components
{
    [GenerateAuthoringComponent]
    public struct ParticuleComponent : IComponentData
    {

        public float m_LifeTime;

    }
}
