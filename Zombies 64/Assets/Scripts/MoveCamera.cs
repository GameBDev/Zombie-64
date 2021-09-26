using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField] Transform cameraPostition;

    void Update()
    {
        transform.position = cameraPostition.position;
    }
}
