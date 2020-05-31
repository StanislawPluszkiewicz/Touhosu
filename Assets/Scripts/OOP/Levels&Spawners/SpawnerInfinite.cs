using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class SpawnerInfinite : MonoBehaviour
	{
		[SerializeField] float TimeBetweenEnemy = 10;
		[SerializeField] float TimeBetweenEnemyHard = 3;
		[SerializeField] float EnemiesAmountToGetHard = 10;

		int enemyCount = 0;
		float nextShip = Time.time;
		public List<Enemy> prefabs;

		public void Update()
		{
			if (Time.time >= nextShip)
			{
				Spawn();
				nextShip += TimeBetweenEnemy - (TimeBetweenEnemy - TimeBetweenEnemyHard) * (enemyCount / EnemiesAmountToGetHard);
				if(enemyCount < EnemiesAmountToGetHard)
					enemyCount++;
			}
		}

		public void Spawn()
		{
			int i = Helper.RandomBetween(0, prefabs.Count);
			Enemy e = Instantiate(prefabs[i]) as Enemy;
			e.transform.parent = transform;
			e.transform.position = transform.position;
		}
	}
}
