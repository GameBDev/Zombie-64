using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMove : MonoBehaviour
{
    public float doorMoveSpeed;
    public float destroylev;
    public void Doormove()
    {
        transform.Translate(Vector3.up * doorMoveSpeed * Time.deltaTime);
        print("Ok Opening Door");
    }
    private void Update()
    {
        if (transform.position.y >= destroylev)
        {
            Destroy(gameObject);
        }
    }
}
