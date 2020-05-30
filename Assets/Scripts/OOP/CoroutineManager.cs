using UnityEngine;
using Sirenix.OdinInspector;

namespace Game
{
	[ExecuteInEditMode]
	class CoroutineManager : SerializedMonoBehaviour
	{
		[ReadOnly, ShowInInspector] private static CoroutineManager instance;
		public static CoroutineManager Instance { get { return instance; } }

		private void Awake()
		{
			if (instance != null && instance != this)
			{
				Destroy(gameObject);
			}
			else
			{
				instance = this;
			}
		}
	}
}
