using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
	static class BulletManager
	{
		static Dictionary<uint, Bullet> m_Bullets;
		public static Bullet Get(uint id) => m_Bullets[id];
		public static void Add(uint id, Bullet b) => m_Bullets[id] = b;
		public static void Remove(uint id) => m_Bullets.Remove(id);
	}
}
