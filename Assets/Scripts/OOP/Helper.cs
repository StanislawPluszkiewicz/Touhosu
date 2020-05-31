using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public static class Helper
    {
        public static System.Random rng = new System.Random();

        public static float RandomBetweenFloats(float min, float max)
        {
            return min + (max - min) * (float)rng.NextDouble();
        }

		public static int RandomBetween(int min, int max)
		{
			return min + (max - min) * (int)rng.NextDouble();
		}

		public static void Destroy(UnityEngine.GameObject go)
		{
			if (UnityEngine.Application.isPlaying)
				UnityEngine.Object.Destroy(go);
			else if (UnityEngine.Application.isEditor)
			{
				UnityEngine.Object.Destroy(go);
				try
				{
					UnityEngine.Object.DestroyImmediate(go);
				}
				catch (System.Exception)
				{
					UnityEngine.Object.Destroy(go);
				}
			}
				
		}
	}
}
