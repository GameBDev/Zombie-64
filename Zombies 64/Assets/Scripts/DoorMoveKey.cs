using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMoveKey : MonoBehaviour
{
    public float doorMoveSpeedKey;
    public float destroylevKey;
    public void Doormove()
    {
        transform.Translate(Vector3.up * doorMoveSpeedKey * Time.deltaTime);
        print("Ok Opening Door");
    }
    private void Update()
    {
        if (transform.position.y >= destroylevKey)
        {
            Destroy(gameObject);
        }
    }
}
