using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDrops : MonoBehaviour
{
    public GameObject[] drops;
    private void OnDestroy()
    {
        int dropIndex = Random.Range(0, drops.Length);

        Instantiate(drops[dropIndex], transform.position, transform.rotation);
    }
}
