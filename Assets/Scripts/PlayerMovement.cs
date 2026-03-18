using UnityEngine;
using UnityEngine.InputSystem; 

public class PlayerMovement : MonoBehaviour
{[Header("Movement Settings")]
    public float moveSpeed = 5f; // Speed of the player movement
    public float jumpForce = 10f; // Force applied when the player jumps

    [Header("Environment Physics")]
    public Transform groundCheck; // Position to check if the player is grounded
    public LayerMask groundLayer; // Layer that represents the ground
    public float groundCheckRadius = 0.2f; // Radius for checking if the player is grounded

    private Rigidbody2D rb; // Reference to the player's Rigidbody
    private float horizontalInput; // Horizontal input from the player
    private bool isGrounded; // Whether the player is currently grounded

    // define input actions
    private InputAction moveAction;
    private InputAction jumpAction;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        // input system
        moveAction = new InputAction("Move");
        moveAction.AddCompositeBinding("Axis")
            .With("Positive", "<Keyboard>/d")
            .With("Negative", "<Keyboard>/a")
            .With("Positive", "<Keyboard>/rightArrow")
            .With("Negative", "<Keyboard>/leftArrow");
        
        jumpAction = new InputAction("Jump", binding: "<Keyboard>/space");
    }

    // enable and disable input actions
    void OnEnable()
    {
        moveAction.Enable();
        jumpAction.Enable();
    }

    void OnDisable()
    {
        moveAction.Disable();
        jumpAction.Disable();
    }

    
    void Update()
    {
        // read value for move action
        horizontalInput = moveAction.ReadValue<float>();

        // check if the player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // handle jump checking
        if (jumpAction.WasPressedThisFrame() && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        // death/respawn logic
        if (transform.position.y < -15f) // if player falls below a certain point
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
             // reload the current scene to respawn the player
        }
    }

    
    void FixedUpdate()
    {
        // apply horizontal movement
        rb.linearVelocity = new Vector2(horizontalInput * moveSpeed, rb.linearVelocity.y);
    }
}