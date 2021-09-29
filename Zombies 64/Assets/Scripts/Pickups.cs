using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{


     void OnTriggerEnter(Collider other)
     {
        if(other.tag == "Player")
        {
            Enabled();
        }
     }
    void Enabled()
    {
        
    }
}
