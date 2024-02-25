using Cinemachine;
using NaughtyAttributes;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DinoGame
{
    /// <summary>
    ///     Registers this object as target for a Cinemachine FreeLook camera. If no camera is set, it will attempt to find one
    ///     to use. Orbits for the camera are set based on the size of the object's collider.
    ///     It has options to customize the follow and look at targets and a zoom feature.
    /// </summary>
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private CinemachineFreeLook cinemachineFreeLook;

        [Header("Follow Target")]
        [SerializeField] private TargetType followTargetType = TargetType.Origin;
        [SerializeField] private Vector3 followTargetOffset;

        [Header("Look At Target")]
        [SerializeField] private TargetType lookAtTargetType = TargetType.Center;
        [SerializeField] private Vector3 lookAtTargetOffset;

        [Header("Orbits")]
        [SerializeField] private float scale = 1.0f;
        [SerializeField] private float topRigHeightMultiplier = 1.5f;
        [SerializeField] private float topRigRadiusMultiplier = 0.3f;
        [SerializeField] private float middleRigHeightMultiplier = 0.8f;
        [SerializeField] private float middleRigRadiusMultiplier = 0.6f;
        [SerializeField] private float bottomRigHeightMultiplier = 0.1f;
        [SerializeField] private float bottomRigRadiusMultiplier = 0.3f;

        [Header("Zoom")]
        [SerializeField] private InputActionReference zoomAction;
        [SerializeField] private float zoomSpeed = 1.0f;

        [Header("Info")]
        [ReadOnly] private CinemachineCameraOffset cinemachineCameraOffset;

        private void Awake()
        {
            if (cinemachineFreeLook == null)
            {
                Debug.Log("CinemachineFreeLook camera is not set. Attempting to find best camera to use.");
                cinemachineFreeLook = DetermineCamera();
            }

            if (cinemachineFreeLook != null)
            {
                SetupCameraTargets();
                SetupOrbits();
                SetupZoomComponent();
            }
            else
            {
                Debug.LogError(
                    "Can't setup camera without a CinemachineFreeLook camera. Please assign it in the inspector.");
            }
        }

        private void OnEnable()
        {
            zoomAction.action.Enable();
            zoomAction.action.performed += OnZoom;
        }

        private CinemachineFreeLook DetermineCamera()
        {
            // Check if there is a main camera
            if (Camera.main == null)
            {
                Debug.LogWarning("Main camera not found.");
                return null;
            }

            // Get CinemachineBrain
            if (!Camera.main.TryGetComponent(out CinemachineBrain cinemachineBrain))
            {
                Debug.LogWarning("CinemachineBrain not found.");
                return null;
            }

            // Get all CinemachineFreeLook cameras
            CinemachineFreeLook[] freeLookCameras = FindObjectsOfType<CinemachineFreeLook>();
            if (freeLookCameras.Length == 0)
            {
                Debug.LogWarning("No CinemachineFreeLook cameras found.");
                return null;
            }

            // Find the best camera to use. If the active camera is not a CinemachineFreeLook, use the one with the highest priority.
            CinemachineFreeLook cam =
                freeLookCameras.FirstOrDefault(x => ReferenceEquals(cinemachineBrain.ActiveVirtualCamera, x))
                ?? freeLookCameras.OrderByDescending(x => x.Priority).FirstOrDefault();

            if (cam == null)
            {
                Debug.LogError("Error trying to find CinemachineFreeLook camera.");
            }

            return cam;
        }

        private void OnZoom(InputAction.CallbackContext obj)
        {
            float zoomValue = obj.ReadValue<float>();
            switch (zoomValue)
            {
                // Scroll up -> Zoom in
                case > 0.0f:
                    cinemachineCameraOffset.m_Offset.z += zoomSpeed;
                    break;
                // Scroll down -> Zoom out
                case < 0.0f:
                    cinemachineCameraOffset.m_Offset.z -= zoomSpeed;
                    break;
            }
        }

        private void SetupOrbits()
        {
            Bounds bounds = GetColliderBounds();

            if (bounds.size == Vector3.zero)
            {
                Debug.LogError("Bounds size is zero. Cannot setup orbits.");
                return;
            }

            // Get the height and width of the bounds
            float modelHeight = bounds.size.y;
            float modelWidth = Mathf.Max(bounds.size.x, bounds.size.z);

            // Change height and radius of the orbits
            cinemachineFreeLook.m_Orbits[0].m_Height = modelHeight * topRigHeightMultiplier * scale;
            cinemachineFreeLook.m_Orbits[0].m_Radius = modelWidth * topRigRadiusMultiplier * scale;
            cinemachineFreeLook.m_Orbits[1].m_Height = modelHeight * middleRigHeightMultiplier * scale;
            cinemachineFreeLook.m_Orbits[1].m_Radius = modelWidth * middleRigRadiusMultiplier * scale;
            cinemachineFreeLook.m_Orbits[2].m_Height = modelHeight * bottomRigHeightMultiplier * scale;
            cinemachineFreeLook.m_Orbits[2].m_Radius = modelWidth * bottomRigRadiusMultiplier * scale;
        }

        private Bounds GetColliderBounds()
        {
            // Get all the Collider components in the object and its children
            Collider[] colliders = GetComponentsInChildren<Collider>();

            // Initialize the bounds to the bounds of the first Collider
            Bounds combinedBounds = colliders[0].bounds;

            // For each subsequent Collider, expand the bounds to include the Collider's bounds
            for (int i = 1; i < colliders.Length; i++)
            {
                combinedBounds.Encapsulate(colliders[i].bounds);
            }

            return combinedBounds;
        }

        private void SetupCameraTargets()
        {
            // Retrieve object transform
            Transform objectTransform = transform;

            // Create targets
            Transform followTransform =
                CreateTargetObject(objectTransform, followTargetType, followTargetOffset, "FollowTarget").transform;
            Transform lookAtTransform =
                CreateTargetObject(objectTransform, lookAtTargetType, lookAtTargetOffset, "LookAtTarget").transform;

            // Assign the targets to the Cinemachine FreeLook camera
            cinemachineFreeLook.Follow = followTransform;
            cinemachineFreeLook.LookAt = lookAtTransform;
        }

        private GameObject CreateTargetObject(Transform parentTransform, TargetType targetType = TargetType.Origin,
            Vector3 offset = default, string objectName = "Target")
        {
            GameObject targetObject = new(objectName);

            switch (targetType)
            {
                case TargetType.Origin:
                    {
                        targetObject.transform.position = parentTransform.position + offset;
                        break;
                    }

                case TargetType.Center:
                    {
                        Bounds bounds = GetColliderBounds();
                        targetObject.transform.position = bounds.center + offset;
                        break;
                    }
                case TargetType.CenterTop:
                    {
                        Bounds bounds = GetColliderBounds();
                        targetObject.transform.position = bounds.center + new Vector3(0, bounds.extents.y, 0) + offset;
                        break;
                    }
            }

            // Assign focus target to object as a child
            targetObject.transform.parent = parentTransform;

            return targetObject;
        }

        private void SetupZoomComponent()
        {
            cinemachineCameraOffset = cinemachineFreeLook.AddComponent<CinemachineCameraOffset>();
        }

        private enum TargetType
        {
            Origin,
            Center,
            CenterTop
        }
    }
}