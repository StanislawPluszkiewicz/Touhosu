using UnityEngine;
using UnityEditor;

namespace Game
{
	[System.Serializable]
	public static class Boundary
	{
		public static float xMin = -100f;
		public static float xMax = 100f;
		public static float yMin = -55f;
		public static float yMax = 55f;

		public static Vector3 ClampPosition(Vector3 v, float height = 0.0f)
		{
			return new Vector3
			(
				Mathf.Clamp(v.x, xMin, xMax),
				Mathf.Clamp(v.y, yMin, yMax),
				height
			);
		}

		public static void ShowGizmos(Color color)
		{
			Gizmos.color = color;
			Vector3 upLeft = Vector3.right * xMin + Vector3.up * yMax;
			Vector3 upRight = Vector3.right * xMax + Vector3.up * yMax;
			Vector3 downLeft = Vector3.right * xMin + Vector3.up * yMin;
			Vector3 downRight = Vector3.right * xMax + Vector3.up * yMin;
			
			Gizmos.DrawLine(upLeft, upRight);
			Gizmos.DrawLine(upRight, downRight);
			Gizmos.DrawLine(downRight, downLeft);
			Gizmos.DrawLine(downLeft, upLeft);
		}
	}
}
