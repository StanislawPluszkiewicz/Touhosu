using Game;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class Wave : MonoBehaviour
{
    public Enemy EnemyToSpawn;
    public float TimeBeforeWave = 2;
    public int AmountToSpawn = 5;
    public float TimeBetweenEachEnemy = 1;

    int enemySpawned = 0;
    float timeForSpawn;
    bool allEnemiesInvoked = false;

    private void Start()
    {
        timeForSpawn = Time.time + TimeBeforeWave;
    }
    // Update is called once per frame
    void Update()
    {
        if(Time.time >= timeForSpawn && !allEnemiesInvoked)
        {
            Spawn();
            enemySpawned++;
            if (enemySpawned < AmountToSpawn)
                timeForSpawn += TimeBetweenEachEnemy;
            else
                allEnemiesInvoked = true;
        }

        if (allEnemiesInvoked && transform.childCount == 0)
            Destroy(gameObject);
    }

    public void Spawn()
    {
        Enemy e = Instantiate(EnemyToSpawn) as Enemy;
        e.transform.parent = transform;
        e.transform.position = transform.position;
    }
}
