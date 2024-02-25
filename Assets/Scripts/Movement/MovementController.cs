using DinoGame.Input;
using DinoGame.Utility;
using NaughtyAttributes;
using UnityEngine;

namespace DinoGame.Movement
{
    public class MovementController : MonoBehaviour
    {
        [SerializeField] private Rigidbody rb;
        [SerializeField] private Transform cameraTransform;
        [SerializeField] [Required] private PlayerInputReader playerInputReader;
        [SerializeField] [Required] private MovementSettings movementSettings;

        public Vector3 MoveDirection { get; private set; }
        public bool IsGrounded { get; private set; }

        private void Awake()
        {
            rb = gameObject.EnsureComponentExists(rb);
            cameraTransform = Camera.main.gameObject.EnsureComponentExists(cameraTransform);
            movementSettings.ApplyDefaults();
            playerInputReader.MoveEvent += Move;
        }

        private void FixedUpdate()
        {
            IsGrounded = CheckGrounded();
            Vector3 newVelocity = new(MoveDirection.x * movementSettings.MoveSpeed, rb.velocity.y,
                MoveDirection.z * movementSettings.MoveSpeed);
            rb.velocity = newVelocity;

            // Return if the character is not moving
            if (MoveDirection == Vector3.zero)
            {
                return;
            }

            // Rotate the character to face the direction of movement
            Quaternion toRotation = Quaternion.LookRotation(MoveDirection, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation,
                movementSettings.RotationSpeed * Time.deltaTime);
        }

        private bool CheckGrounded()
        {
            // Cast a ray from the GameObject's position downward
            Ray ray = new(transform.position + movementSettings.Offset, Vector3.down);

            // Perform the raycast and check if the player is grounded
            return Physics.Raycast(ray, movementSettings.MaxDistance, movementSettings.LayerMask);
        }

        public void Move(Vector2 moveInput)
        {
            Vector2 inputVector = moveInput.normalized;
            Vector3 cameraForward = cameraTransform.forward;
            Vector3 cameraRight = cameraTransform.right;

            // Project the camera's forward and right vectors onto the plane of movement (y = 0)
            cameraForward.y = 0;
            cameraRight.y = 0;
            cameraForward.Normalize();
            cameraRight.Normalize();

            // Calculate the final move direction based on the camera's orientation
            MoveDirection = (cameraForward * inputVector.y) + (cameraRight * inputVector.x);
        }
    }
}