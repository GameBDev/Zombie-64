using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject spawn;

    public Vector3 enemySpawnVector;

    public float startDelay = 1.0f;
    public float spawnInterval;

    private void Start()
    {
        InvokeRepeating("SpawnNewEnemy", startDelay, spawnInterval);
        enemySpawnVector = spawn.transform.position;
    }
    void Update()
    {
        
    }

    void SpawnNewEnemy()
    {
        int enemiesIndex = Random.Range(0, enemies.Length);

        Instantiate(enemies[enemiesIndex], enemySpawnVector, enemies[0].transform.rotation);
    }
}