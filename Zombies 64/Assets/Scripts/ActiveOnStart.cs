using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveOnStart : MonoBehaviour
{
    public GameObject item;
    void Start()
    {
        item.SetActive(true);
    }   
}
