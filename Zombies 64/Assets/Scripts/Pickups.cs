using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    public float delay;
    public float rotationspeed = 15;
    public GameObject sfx;
     void OnTriggerEnter(Collider other)
     {
        if(other.tag == "Player")
        {
            Destroy(gameObject, delay);
            Instantiate(sfx, transform.position, transform.rotation);        }
     }
    private void Update()
    {
        transform.Rotate(Vector3.up * rotationspeed * Time.deltaTime);
    }
}
