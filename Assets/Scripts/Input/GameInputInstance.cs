using UnityEngine;

namespace DinoGame.Input
{
    /// <summary>
    ///     Holds an instance of the GameInput class and enables/disables it when the scriptable object is enabled/disabled.
    /// </summary>
    [CreateAssetMenu(fileName = "New GameInput Instance", menuName = "Input/GameInput Instance", order = -100)]
    public class GameInputInstance : ScriptableObject
    {
        public GameInput Instance { get; private set; }

        private void OnEnable()
        {
            Instance ??= new GameInput();
            Instance.Enable();
        }

        private void OnDisable()
        {
            Instance?.Disable();
        }
    }
}