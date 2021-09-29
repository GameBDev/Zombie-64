using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    public float delay;

     void OnTriggerEnter(Collider other)
     {
        if(other.tag == "Player")
        {
            Destroy(gameObject, delay);
        }
     }
    
}
