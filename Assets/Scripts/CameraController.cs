using Cinemachine;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CinemachineFreeLook))]
public class CameraController : MonoBehaviour, AxisState.IInputAxisProvider
{
    [Header("Input Actions")]
    [SerializeField] [Required] private InputActionAsset actionAsset;

    [Header("Camera Parameters")]
    [SerializeField] [Range(0.01f, 2.00f)] private float sensitivity = 0.5f;

    private InputAction lookAction;
    private Vector2 lookInput;

    private void Awake()
    {
        // Initialize Input Actions
        var playerActionMap = actionAsset.FindActionMap("Player");
        lookAction = playerActionMap.FindAction("Look");

        // Subscribe to Input Actions
        lookAction.performed += OnLook;
        lookAction.canceled += OnLook;
    }

    private void OnEnable()
    {
        lookAction.Enable();
    }

    private void OnDisable()
    {
        lookAction.Disable();
    }

    public float GetAxisValue(int axis)
    {
        return axis switch
        {
            // X-axis (Horizontal)
            0 => lookInput.x,
            // Y-axis (Vertical)
            1 => lookInput.y,
            _ => 0
        };
    }

    private void OnLook(InputAction.CallbackContext context)
    {
        lookInput = new Vector2(-context.ReadValue<Vector2>().x, -context.ReadValue<Vector2>().y) * sensitivity;
    }
}
