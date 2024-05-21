using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    public List<Transform> worldPoints;
    public List<Enemy> enemies;
    
    [HideInInspector]
    public List<Enemy> spawnedEnemies;

    private void Start()
    {
        SpawnEnemy(20);
    }

    public void SpawnEnemy(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            Enemy enemy = Instantiate(enemies[Random.Range(0, enemies.Count)], worldPoints[Random.Range(0, worldPoints.Count)].position, Quaternion.identity);
            spawnedEnemies.Add(enemy);
        }
    }

    public void CheckForWin()
    {
        if(spawnedEnemies.Count == 0)
        {
            LoadWinScreenScene();
        }
    }

    public void LoadWinScreenScene()
    {
        SceneManager.LoadScene("Win screen");
    }
}
