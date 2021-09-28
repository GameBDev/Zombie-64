using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    float playerHeight = 2f;

    [SerializeField] Transform oriantation;

    [Header("Health")]
    [SerializeField] int maxHealth;
    [SerializeField] int currentHealth;
    [SerializeField] HealthBar healthBar;
    [SerializeField] int damageInt;
    [SerializeField] Text text;


    [Header("Attack Damages")]
    [SerializeField] int Attack1;
    [SerializeField] int Attack2;
    [SerializeField] int Attack3;
    [SerializeField] int Attack4;
    [SerializeField] int Attack5;
    bool canDamage1;
    bool canDamage2;
    bool canDamage3;
    bool canDamage4;
    bool canDamage5;

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

    [Header("Death")]
    [SerializeField] GameObject gameOver;
    [SerializeField] GameObject gameOverText;
    [SerializeField] GameObject health;
    [SerializeField] GameObject grayBar;
    [SerializeField] GameObject healthInt;
    [SerializeField] GameObject crossAir;
    [SerializeField] GameObject gun;

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

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
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

        if(currentHealth <= 0)
        {
            GameOver();
        }

        text.text = currentHealth.ToString();

        if (Input.GetKeyDown(KeyCode.Y))
        {
            TakeDamage(damageInt);
        }

        if (canDamage1)
        {
            TakeDamage(Attack1);
        }

        if (canDamage2)
        {
            TakeDamage(Attack2);
        }

        if (canDamage3)
        {
            TakeDamage(Attack3);
        }

        if (canDamage4)
        {
            TakeDamage(Attack4);
        }

        if (canDamage5)
        {
            TakeDamage(Attack5);
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
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        canDamage1 = false;
        canDamage2 = false;
        canDamage3 = false;
        canDamage4= false;
        canDamage5 = false;

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Attack1")
        {
            canDamage1 = true;
        }
        if (other.gameObject.tag == "Attack2")
        {
            canDamage2 = true;
        }
        if (other.gameObject.tag == "Attack3")
        {
            canDamage3 = true;
        }
        if (other.gameObject.tag == "Attack4")
        {
            canDamage4 = true;
        }
        if (other.gameObject.tag == "Attack5")
        {
            canDamage5 = true;
        }
    }
    void GameOver()
    {       
        gameOver.SetActive(true);
        gameOverText.SetActive(true);
        health.SetActive(false);
        healthInt.SetActive(false);
        grayBar.SetActive(false);
        crossAir.SetActive(false);
        gun.SetActive(false);
        Destroy(gameObject);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
