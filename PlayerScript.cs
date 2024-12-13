// Chase Anderson

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private float y;
    public float sensitivity = -1f; // Mouse Sensitivity
    private Vector3 rotate;

    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float sprintMultiplier = 1.5f;  // Sprint speed multiplier
    private float currentMoveSpeed;  // To store the current move speed based on sprint


    [Header("Jump Settings")]
    public float jumpForce = 5f; // Jump Force
    public Transform groundCheck; // Check what the ground is
    public float groundCheckRadius = 0.2f; // radius of when the player touches the ground
    public LayerMask groundLayer; // Check if ground is layered as ground

    private Rigidbody rb; // reference to rigidbody
    private bool isGrounded; // checks if the player is touching the ground

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody component missing from the player.");
        }
        Cursor.lockState = CursorLockMode.Locked; // locks the cursor to the screen for smoother gameplay 
        currentMoveSpeed = moveSpeed; // Set initial move speed
    }
    
    void Update()
    {
        y = Input.GetAxis("Mouse X");
        rotate = new Vector3(0, y * sensitivity, 0);
        transform.eulerAngles = transform.eulerAngles - rotate;

        // Check for sprint input (Left Shift key)
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentMoveSpeed = moveSpeed * sprintMultiplier;  // Increase speed when holding shift
        }
        else
        {
            currentMoveSpeed = moveSpeed;  // Default speed when shift is not held
        }

        Jump();
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        // Get input for movement
        float moveX = Input.GetAxis("Horizontal"); // A/D or Left/Right
        float moveZ = Input.GetAxis("Vertical");   // W/S or Up/Down

        // Calculate movement direction relative to the player's facing direction
        Vector3 moveDirection = transform.right * moveX + transform.forward * moveZ;

        // Normalize the movement direction to ensure consistent speed
        moveDirection = moveDirection.normalized;

        // Move the player using Rigidbody
        Vector3 velocity = moveDirection * moveSpeed;
        velocity.y = rb.velocity.y; // Preserve vertical velocity
        rb.velocity = velocity;
    }

    private void Jump()
    {
        // Check if the player is grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);

        // Jump if the spacebar is pressed and the player is grounded
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
