using Game;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class Wave : MonoBehaviour
{
    public Enemy EnemyToSpawn;
    public float TimeBeforeWave;
    public int EnemyAmount;
    public float TimeBetweenEachEnemy;

    public int enemySpawned = 0;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn()
    {
        Enemy e = Instantiate(EnemyToSpawn) as Enemy;
        e.transform.parent = transform;
        e.transform.position = transform.position;
    }
}
