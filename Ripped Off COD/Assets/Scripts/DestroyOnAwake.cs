using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnAwake : MonoBehaviour
{
    public float delay;
    private void Awake()
    {
        Destroy(gameObject, delay);
    }
}
