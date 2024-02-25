using NaughtyAttributes;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DinoGame.Input
{
    /// <summary>
    ///     Registers callbacks for the Player input actions and invokes events when the input actions are triggered.
    ///     The reader can be used anywhere in the project to listen for input.
    /// </summary>
    [CreateAssetMenu(fileName = "New Player Input Reader", menuName = "Input/Player Input Reader")]
    public class PlayerInputReader : ScriptableObject, GameInput.IPlayerActions
    {
        [SerializeField] [Required] private GameInputInstance gameInput;

        private void OnEnable()
        {
            // Add the callbacks to the input actions
            gameInput.Instance.Player.AddCallbacks(this);
        }

        private void OnDisable()
        {
            // Remove the callbacks from the input actions
            gameInput.Instance.Player.RemoveCallbacks(this);
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            MoveEvent?.Invoke(context.ReadValue<Vector2>());

            if (context.started)
            {
                MoveEventStarted?.Invoke(context.ReadValue<Vector2>());
            }
            else if (context.performed)
            {
                MoveEventPerformed?.Invoke(context.ReadValue<Vector2>());
            }
            else if (context.canceled)
            {
                MoveEventCancelled?.Invoke(context.ReadValue<Vector2>());
            }
        }

        public event Action<Vector2> MoveEvent;
        public event Action<Vector2> MoveEventStarted;
        public event Action<Vector2> MoveEventPerformed;
        public event Action<Vector2> MoveEventCancelled;
    }
}