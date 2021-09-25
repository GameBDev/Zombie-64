using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float playerHeight = 2f;

    [SerializeField] Transform oriantation;

    [Header("Movement")]
    [SerializeField] float moveSpeed = 6f;    
    [SerializeField] float airMultiplier = 0.4f;
    float movementMultiplier = 10;

    [Header("Sprinting")]
    [SerializeField] float walkSpeed = 4f;
    [SerializeField] float sprintSpeed = 6f;
    [SerializeField] float acceleration = 10f;

    [Header("Jumping")]
    public float jumpForce = 5f;
    public float gravity;
    public float fallForce = 5f;
    public float fallingAcceleration;

    [Header("KeyBinds")]
    [SerializeField] KeyCode jumpKey = KeyCode.Space;
    [SerializeField] KeyCode sprintKey = KeyCode.LeftShift;
    

    [Header("Drag")]
    [SerializeField] float groundDrag = 6f;
    [SerializeField] float airDrag = 2;

    float horizontalMovement;
    float verticalMovement;

    [Header("Ground Detection")]
    [SerializeField] LayerMask groundMask;
    [SerializeField] float groundDistance = 0.4f;
    bool isGrounded;

    Vector3 moveDirection;
    Vector3 slopeMoveDirection;

    Rigidbody rb;

    RaycastHit slopeHit;

    private bool OnSlope()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out slopeHit, playerHeight / 2 + 0.5f))
        {
            if (slopeHit.normal != Vector3.up)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }
    private void Update()
    {
        isGrounded = Physics.CheckSphere(transform.position - new Vector3(0,1,0), groundDistance,  groundMask);

        MyInput();
        ControlDrag();
        ControlSpeed();

        if (Input.GetKeyDown(jumpKey) && isGrounded)
        {
            Jump();
        }

        slopeMoveDirection = Vector3.ProjectOnPlane(moveDirection, slopeHit.normal);

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
    void MyInput()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");

        moveDirection = oriantation.forward * verticalMovement + oriantation.right * horizontalMovement;
    }
    void Jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);        
    }
    void ControlSpeed()
    {
        if (Input.GetKey(sprintKey) && isGrounded)
        {
            moveSpeed = Mathf.Lerp(moveSpeed, sprintSpeed, fallingAcceleration * Time.deltaTime);
        }
        else
        {
            moveSpeed = Mathf.Lerp(moveSpeed, walkSpeed, acceleration * Time.deltaTime);
        }
    }
    void ControlDrag()
    {
        if (isGrounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = airDrag;
        }
    }
    private void FixedUpdate()
    {
        MovePlayer();
    }
    void MovePlayer()
    {
        if (isGrounded && !OnSlope())
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * movementMultiplier, ForceMode.Acceleration);
        }
        else if (isGrounded && OnSlope())
        {
            rb.AddForce(slopeMoveDirection.normalized * moveSpeed * movementMultiplier, ForceMode.Acceleration);
        }
        else if (!isGrounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * movementMultiplier * airMultiplier, ForceMode.Acceleration);
        }
    }
}

