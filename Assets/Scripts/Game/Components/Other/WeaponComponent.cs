
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unity.Entities;

namespace Components
{
    [GenerateAuthoringComponent]
    public struct WeaponComponent : IComponentData {


        public float m_FireRate;

        private float m_LastFire;


        /*public Bullet m_Bullet;

        public Emitter[] m_Emitters;*/

    }
}