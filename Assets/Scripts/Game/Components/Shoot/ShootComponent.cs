using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unity.Entities;

namespace Game.Components
{
    [GenerateAuthoringComponent]
    public struct ShootComponent : IComponentData
	{
        public bool m_DoShoot;
		public uint m_BulletId;
		public int m_FireRate;
		public int m_NextFire;
    }
}