using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public List<Transform> worldPoints;
    public List<Enemy> enemies;
    
    [HideInInspector]
    public List<Enemy> spawnedEnemies;

    private void Start()
    {
        SpawnEnemy(100);
    }

    public void SpawnEnemy(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            Enemy enemy = Instantiate(enemies[Random.Range(0, enemies.Count)], worldPoints[Random.Range(0, worldPoints.Count)].position, Quaternion.identity);
            spawnedEnemies.Add(enemy);
        }
    }
}
