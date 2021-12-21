using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawning : MonoBehaviour
{
    public GameObject Boss;
    public Transform BossSpawn;
    private float nextActionTime = 600f;
    public float period = 0.1f;

    void Update()
    {
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;
            Instantiate(Boss, BossSpawn.position, BossSpawn.rotation);
        }
    }
}
