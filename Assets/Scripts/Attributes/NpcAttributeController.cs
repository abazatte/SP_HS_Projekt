using DinoGame.GameEvents.Types;
using NaughtyAttributes;
using UnityEngine;

namespace DinoGame.Attributes
{
    /// <summary>
    ///     This script is responsible for setting up the NPC's attributes and their listeners.
    /// </summary>
    public class NpcAttributeController : MonoBehaviour
    {
        [SerializeField] [Required] private NpcAttributes npcAttributes;

        // Events
        [SerializeField] [Required] private FloatGameEvent healthChangedEvent;

        // Listeners
        private FloatGameEventListener _healthListener;

        private void Awake()
        {
            npcAttributes.ApplyDefaults();
            SetupHealthListener();
        }

        private void SetupHealthListener()
        {
            _healthListener = gameObject.AddComponent<FloatGameEventListener>();
            _healthListener.GameEvent = healthChangedEvent;
            _healthListener.UnityEvent.AddListener(npcAttributes.ModifyHealth);
        }
    }
}