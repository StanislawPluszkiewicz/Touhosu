using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public static class Helper
    {
        public static Random rng = new Random();

        public static float RandomBetweenFloats(float min, float max)
        {
            return min + (max - min) * (float)rng.NextDouble();
        }

		public static int RandomBetween(int min, int max)
		{
			return min + (max - min) * (int)rng.NextDouble();
		}
	}
}
