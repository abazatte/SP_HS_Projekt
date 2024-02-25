using DinoGame.GameEvents.Types;
using NaughtyAttributes;
using UnityEngine;

namespace DinoGame.Attributes
{
    /// <summary>
    ///     This script is responsible for setting up the player's attributes and their listeners.
    /// </summary>
    public class PlayerAttributeController : MonoBehaviour
    {
        [SerializeField] [Required] private PlayerAttributes playerAttributes;

        // Events
        [SerializeField] [Required] private FloatGameEvent healthChangedEvent;
        [SerializeField] [Required] private FloatGameEvent hungerChangedEvent;
        [SerializeField] [Required] private FloatGameEvent thirstChangedEvent;

        // Listeners
        private FloatGameEventListener _healthListener;
        private FloatGameEventListener _hungerListener;
        private FloatGameEventListener _thirstListener;

        private void Awake()
        {
            playerAttributes.ApplyDefaults();
            SetupHealthListener();
            SetupHungerListener();
            SetupThirstListener();
        }

        private void SetupHealthListener()
        {
            _healthListener = gameObject.AddComponent<FloatGameEventListener>();
            _healthListener.GameEvent = healthChangedEvent;
            _healthListener.UnityEvent.AddListener(playerAttributes.ModifyHealth);
        }

        private void SetupHungerListener()
        {
            _hungerListener = gameObject.AddComponent<FloatGameEventListener>();
            _hungerListener.GameEvent = hungerChangedEvent;
            _hungerListener.UnityEvent.AddListener(playerAttributes.ModifyHunger);
        }

        private void SetupThirstListener()
        {
            _thirstListener = gameObject.AddComponent<FloatGameEventListener>();
            _thirstListener.GameEvent = thirstChangedEvent;
            _thirstListener.UnityEvent.AddListener(playerAttributes.ModifyThirst);
        }
    }
}