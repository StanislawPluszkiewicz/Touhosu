using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Game
{
	public abstract class Component : MonoBehaviour
	{
		public abstract void CompositeOperation();
	}
}