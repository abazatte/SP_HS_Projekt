using UnityEngine;

namespace DinoGame.Utility
{
    /// <summary>
    ///     Provides debugging capabilities for a camera in the game by drawing a debug ray from the camera's position in the
    ///     direction the camera is facing.
    /// </summary>
    public class CameraDebug : MonoBehaviour
    {
        [Header("Debug Parameters")]
        [SerializeField] private float rayLength = 10f;
        [SerializeField] private Color rayColor = Color.red;

        private Transform _cachedTransform;

        private void Awake()
        {
            _cachedTransform = transform;
        }

        private void Update()
        {
            Debug.DrawRay(_cachedTransform.position, _cachedTransform.forward * rayLength, rayColor);
        }
    }
}