using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    public GameObject gun1;
    public GameObject gun2;

    private void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            gun1.SetActive(true);
            gun2.SetActive(false);

            print("1");
        }
        if (Input.GetKeyDown("2"))
        {
            gun1.SetActive(false);
            gun2.SetActive(true);

            print("2");
        }
    }
}
