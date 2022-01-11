using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKey : MonoBehaviour
{
    public GameObject player;
    public GameObject door;
    public float openDist;
    float dist;
    public bool hasKey;

    void Update()
    {
        dist = Vector3.Distance(player.transform.position, transform.position);

        if (dist <= openDist && Input.GetKeyDown(KeyCode.E) && hasKey)
        {
            Open();
        }
    }
    void Open()
    {
        print("Door Open");
        DoorMoveKey doorMove = door.GetComponent<DoorMoveKey>();
        doorMove.Doormove();
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, dist);
    }
}