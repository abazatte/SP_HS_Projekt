using DinoGame.Input;
using DinoGame.Movement;
using DinoGame.Utility;
using NaughtyAttributes;
using System.Collections;
using UnityEngine;

namespace DinoGame.Animations
{
    /// <summary>
    ///     Handles the player's animations based on the input and movement settings.
    /// </summary>
    public class AnimationController : MonoBehaviour
    {
        [SerializeField] [Required] private MovementSettings movementSettings;
        [SerializeField] [Required] private PlayerInputReader playerInputReader;

        private Animator _animator;
        private PlayerAnimatorWrapper _playerAnimator;
        private Coroutine _velocityCoroutine;

        private void Awake()
        {
            _animator = gameObject.EnsureComponentExists(_animator);
            _playerAnimator = new PlayerAnimatorWrapper(_animator);
        }

        private void OnEnable()
        {
            // Register to the input events
            playerInputReader.MoveEventStarted += HandleMoveEventStarted;
            playerInputReader.MoveEventCancelled += HandleMoveEventCancelled;
        }

        private void OnDisable()
        {
            // Unregister from the input events
            playerInputReader.MoveEventStarted -= HandleMoveEventStarted;
            playerInputReader.MoveEventCancelled -= HandleMoveEventCancelled;
        }

        private void HandleMoveEventStarted(Vector2 moveInput)
        {
            // Reset the coroutine if it is running
            ResetCoroutine(ref _velocityCoroutine);

            // Start accelerating if coroutine is not running
            _velocityCoroutine = StartCoroutine(IncreaseAcceleration());
        }

        private void HandleMoveEventCancelled(Vector2 moveInput)
        {
            // Reset the coroutine if it is running
            ResetCoroutine(ref _velocityCoroutine);

            // Start decelerating if coroutine is not running
            _velocityCoroutine = StartCoroutine(DecreaseAcceleration());
        }

        private IEnumerator IncreaseAcceleration()
        {
            while (movementSettings.Acceleration < 1.0f)
            {
                movementSettings.Acceleration += movementSettings.AccelerationRate * Time.deltaTime;
                _playerAnimator?.SetVelocityZ(movementSettings.Acceleration);
                yield return null;
            }
        }

        private IEnumerator DecreaseAcceleration()
        {
            while (movementSettings.Acceleration > 0.0f)
            {
                movementSettings.Acceleration -= movementSettings.DecelerationRate * Time.deltaTime;
                _playerAnimator?.SetVelocityZ(movementSettings.Acceleration);
                yield return null;
            }
        }

        private void ResetCoroutine(ref Coroutine coroutine)
        {
            if (coroutine == null)
            {
                return;
            }

            StopCoroutine(coroutine);
            coroutine = null;
        }
    }
}