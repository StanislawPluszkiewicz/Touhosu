namespace Game
{
    public static class Helper
    {
		public readonly static float ShipHeights = 5.0f;
        public static System.Random rng = new System.Random();

        public static float RandomBetweenFloats(float min, float max)
        {
            return min + (max - min) * (float)rng.NextDouble();
        }

		public static int RandomBetween(int min, int max)
		{
			return min + (max - min) * (int)rng.NextDouble();
		}

		public static void Destroy(UnityEngine.GameObject go, float seconds = 0.0f)
		{
			if (UnityEngine.Application.isPlaying)
				UnityEngine.Object.Destroy(go, seconds);
			else if (UnityEngine.Application.isEditor)
			{
				try
				{
					UnityEngine.Object.DestroyImmediate(go);
				}
				catch(System.Exception)
				{
					UnityEngine.Object.Destroy(go, seconds);
				}
			}
				
		}
	}
}
