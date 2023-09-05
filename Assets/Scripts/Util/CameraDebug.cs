using UnityEngine;

namespace Util
{
    /// <summary>
    ///     This script is used to draw a ray in the direction the camera is facing.
    /// </summary>
    public class CameraDebug : MonoBehaviour
    {
        [Header("Debug Parameters")]
        [SerializeField] private float rayLength = 10f;
        [SerializeField] private Color rayColor = Color.red;

        private void Update()
        {
            Debug.DrawRay(transform.position, transform.forward * rayLength, rayColor);
        }
    }
}
