using NaughtyAttributes;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DinoGame.Input
{
    /// <summary>
    ///     Registers callbacks for the Camera input actions and invokes events when the input actions are triggered.
    ///     The reader can be used anywhere in the project to listen for input.
    /// </summary>
    [CreateAssetMenu(fileName = "New Camera Input Reader", menuName = "Input/Camera Input Reader")]
    public class CameraInputReader : ScriptableObject, GameInput.ICameraActions
    {
        [SerializeField] [Required] private GameInputInstance gameInput;

        private void OnEnable()
        {
            // Add the callbacks to the input actions
            gameInput.Instance.Camera.AddCallbacks(this);
        }

        private void OnDisable()
        {
            // Remove the callbacks from the input actions
            gameInput.Instance.Camera.RemoveCallbacks(this);
        }

        public void OnLook(InputAction.CallbackContext context)
        {
            LookEvent?.Invoke(context.ReadValue<Vector2>());

            if (context.started)
            {
                LookEventStarted?.Invoke(context.ReadValue<Vector2>());
            }
            else if (context.performed)
            {
                LookEventPerformed?.Invoke(context.ReadValue<Vector2>());
            }
            else if (context.canceled)
            {
                LookEventCancelled?.Invoke(context.ReadValue<Vector2>());
            }
        }

        public void OnZoom(InputAction.CallbackContext context)
        {
            ZoomEvent?.Invoke(context.ReadValue<float>());

            if (context.started)
            {
                ZoomEventStarted?.Invoke(context.ReadValue<float>());
            }
            else if (context.performed)
            {
                ZoomEventPerformed?.Invoke(context.ReadValue<float>());
            }
            else if (context.canceled)
            {
                ZoomEventCancelled?.Invoke(context.ReadValue<float>());
            }
        }

        public event Action<Vector2> LookEvent;
        public event Action<Vector2> LookEventStarted;
        public event Action<Vector2> LookEventPerformed;
        public event Action<Vector2> LookEventCancelled;

        public event Action<float> ZoomEvent;
        public event Action<float> ZoomEventStarted;
        public event Action<float> ZoomEventPerformed;
        public event Action<float> ZoomEventCancelled;
    }
}