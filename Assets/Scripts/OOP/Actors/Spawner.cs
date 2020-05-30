using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class Spawner : MonoBehaviour
	{
		public List<Enemy> prefabs;

		[Button]
		public void Spawn()
		{
			int i = Helper.RandomBetween(0, prefabs.Count);
			Enemy e = Instantiate(prefabs[i]) as Enemy;
			e.transform.parent = transform;
			e.transform.position = transform.position;
		}
	}
}
