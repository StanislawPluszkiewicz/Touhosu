
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unity.Entities;

namespace Game.Components
{
    [GenerateAuthoringComponent]
    public struct AutomaticShootComponent /*: ShootComponent*/ {

        public float m_Interval;

    }
}