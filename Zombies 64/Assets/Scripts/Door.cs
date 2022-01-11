using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject player;
    public GameObject door;
    public float openDist;
    float dist;
   
    void Update()
    {
         dist = Vector3.Distance(player.transform.position, transform.position);

        if(dist <= openDist && Input.GetKeyDown(KeyCode.E))
        {
            Open();
        }              
    }
    void Open()
    {
        print("Door Open");
        DoorMove doorMove = door.GetComponent<DoorMove>();
        doorMove.Doormove();
    }
     void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, dist);
    }
}
