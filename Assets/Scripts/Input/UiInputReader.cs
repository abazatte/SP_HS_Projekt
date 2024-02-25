using NaughtyAttributes;
using UnityEngine;

namespace DinoGame.Input
{
    /// <summary>
    ///     Registers callbacks for the Ui input actions and invokes events when the input actions are triggered.
    ///     The reader can be used anywhere in the project to listen for input.
    /// </summary>
    [CreateAssetMenu(fileName = "New Ui Input Reader", menuName = "Input/Ui Input Reader")]
    public class UiInputReader : ScriptableObject, GameInput.IUiActions
    {
        [SerializeField] [Required] private GameInputInstance gameInput;

        private void OnEnable()
        {
            // Add the callbacks to the input actions
            gameInput.Instance.Ui.AddCallbacks(this);
        }

        private void OnDisable()
        {
            // Remove the callbacks from the input actions
            gameInput.Instance.Ui.RemoveCallbacks(this);
        }
    }
}