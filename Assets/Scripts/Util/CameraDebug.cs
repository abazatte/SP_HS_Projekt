using UnityEngine;

public class CameraDebug : MonoBehaviour
{
    [Header("Debug Parameters")]
    [SerializeField] private float rayLength = 10f;
    [SerializeField] private Color rayColor = Color.red;

    private void Update()
    {
        // Draw a ray in the direction the camera is facing
        Debug.DrawRay(transform.position, transform.forward * rayLength, rayColor);
    }
}
