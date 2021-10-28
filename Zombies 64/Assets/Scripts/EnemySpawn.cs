using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject[] spawn;

    public float startDelay = 1.0f;
    public float spawnInterval;

    private void Start()
    {
        InvokeRepeating("SpawnNewEnemy", startDelay, spawnInterval);
    }
    void Update()
    {
        
    }

    void SpawnNewEnemy()
    {
        int enemiesIndex = Random.Range(0, enemies.Length);
        int spawnLoctions = Random.Range(0, spawn.Length);

        Instantiate(enemies[enemiesIndex], spawn[spawnLoctions].transform.position, spawn[spawnLoctions].transform.rotation);
    }
}