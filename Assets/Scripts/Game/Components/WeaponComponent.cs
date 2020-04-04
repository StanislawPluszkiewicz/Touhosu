
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Components{
    public class WeaponComponent : IComponentData {

        public WeaponComponent() {
        }

        public float m_FireRate;

        private float m_LastFire;

        public Bullet m_Bullet;

        public Emitter[] m_Emitters;

    }
}