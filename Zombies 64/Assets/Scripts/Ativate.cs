using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ativate : MonoBehaviour
{
    public GameObject thing;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            thing.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            thing.SetActive(false);
        }
    }
}
