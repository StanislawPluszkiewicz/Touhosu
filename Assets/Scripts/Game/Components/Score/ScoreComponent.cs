
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unity.Entities;

namespace Game.Components
{

    [GenerateAuthoringComponent]
    public class ScoreComponent : IComponentData {

        public ScoreComponent() {
        }

        public long m_Value;

    }
}