using NaughtyAttributes;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerControl : MonoBehaviour
{
    [Header("Input Actions")]
    [SerializeField] [Required] private InputActionAsset actionAsset;

    [Header("Movement Parameters")]
    [SerializeField] [MinValue(0)] private float speed = 5f;

    [Header("Jumping Parameters")]
    [SerializeField] [MinValue(0)] private float jumpForce = 20f;
    [SerializeField] [MinValue(0)] private float groundCheckDistance = 0.2f;
    [SerializeField] private Vector3 groundCheckOffset = new(0, 0.1f, 0);
    [SerializeField] private LayerMask groundLayer;

    [Header("Camera")]
    [SerializeField] [Required] private Transform cameraTransform;

    private bool isGrounded;
    private InputAction jumpAction;
    private InputAction moveAction;
    private Vector3 moveDirection;
    private Rigidbody rb;

    private void Awake()
    {
        // Initialize the rigidbody
        rb = GetComponent<Rigidbody>();

        // Initialize Input Actions
        var playerActionMap = actionAsset.FindActionMap("Player");
        moveAction = playerActionMap.FindAction("Move");
        jumpAction = playerActionMap.FindAction("Jump");

        // Subscribe to Input Actions
        moveAction.performed += OnMove;
        moveAction.canceled += OnMove;
        jumpAction.performed += OnJump;

        // Check for essential components
        if (cameraTransform == null) Debug.LogWarning("Camera Transform is not set. Please set it in the Inspector.");
    }

    private void Update()
    {
        CheckIfGrounded();
    }

    private void FixedUpdate()
    {
        // Use FixedUpdate for physics-based movement
        var newVelocity = new Vector3(moveDirection.x * speed, rb.velocity.y, moveDirection.z * speed);
        rb.velocity = newVelocity;

        // Rotate the character to face the direction of movement
        if (moveDirection != Vector3.zero)
        {
            var toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, speed * Time.deltaTime);
        }
    }

    private void OnEnable()
    {
        moveAction.Enable();
        jumpAction.Enable();
    }

    private void OnDisable()
    {
        moveAction.Disable();
        jumpAction.Disable();
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        var inputVector = context.ReadValue<Vector2>().normalized;
        var cameraForward = cameraTransform.forward;
        var cameraRight = cameraTransform.right;

        // Project the camera's forward and right vectors onto the plane of movement (y = 0)
        cameraForward.y = 0;
        cameraRight.y = 0;
        cameraForward.Normalize();
        cameraRight.Normalize();

        // Calculate the final move direction based on the camera's orientation
        moveDirection = cameraForward * inputVector.y + cameraRight * inputVector.x;
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        if (isGrounded)
            // Apply jump force only when grounded
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void CheckIfGrounded()
    {
        // Cast a ray from the GameObject's position downward
        var ray = new Ray(transform.position + groundCheckOffset, Vector3.down);

        // Perform the raycast and check if the player is grounded
        isGrounded = Physics.Raycast(ray, groundCheckDistance, groundLayer);
    }
}
