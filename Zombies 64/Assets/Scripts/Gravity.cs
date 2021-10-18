using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    bool isGrounded;
    [SerializeField] LayerMask groundMask;
    [SerializeField] float groundDistance = 0.4f;
    [SerializeField] float gravity;
    [SerializeField] Rigidbody rb;

    [SerializeField] float acceleration = 10f;

    public float fallForce = 5f;
    public float fallingAcceleration;
    void Update()
    {
        isGrounded = Physics.CheckSphere(transform.position - new Vector3(0, 1, 0), groundDistance, groundMask);
              
        gravity = Mathf.Lerp(gravity, fallForce, acceleration * Time.deltaTime);

        rb.AddForce(Vector3.down * gravity * Time.deltaTime);

        if (!isGrounded)
        {
            gravity = fallForce;
        }
        else if (isGrounded)
        {
            gravity = 0;
        }    
    }
}
