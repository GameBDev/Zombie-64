using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private float sensX;
    [SerializeField] private float sensY;

    [SerializeField] Transform cam;
    [SerializeField] Transform oriantation;

    public bool canLook = true;

    float mouseX;
    float mouseY;

    public float multiplier = 0.01f;

    float xRotation;
    float yRotation;

    private void Start()
    {     
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void Update()
    {
        if (canLook)
        {
            Look();
        }
        if (PauseMenu.GameIsPaused)
        {
            canLook = false;
        }
        if (!PauseMenu.GameIsPaused)
        {
            canLook = true;
        }
    }  
    void Look()
    {
        mouseX = Input.GetAxisRaw("Mouse X");
        mouseY = Input.GetAxisRaw("Mouse Y");

        yRotation += mouseX * sensX * multiplier;
        xRotation -= mouseY * sensY * multiplier;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cam.transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0);
        oriantation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
