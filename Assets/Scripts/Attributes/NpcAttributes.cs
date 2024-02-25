using NaughtyAttributes;
using System;
using UnityEngine;

namespace DinoGame.Attributes
{
    [CreateAssetMenu(fileName = "New NPC Attributes", menuName = "Attributes/NPC")]
    public class NpcAttributes : ScriptableObject
    {
        [Header("Health")]
        [SerializeField] [ProgressBar("Health", "maxHealth", EColor.Red)]
        private float health;
        [SerializeField] private float maxHealth = 100f;
        [SerializeField] private DefaultHealth defaultHealth;

        public float Health
        {
            get => health;
            private set => health = Mathf.Clamp(value, 0, MaxHealth);
        }

        public float MaxHealth
        {
            get => maxHealth;
            set => maxHealth = value;
        }

        public void ModifyHealth(float amount)
        {
            Health += amount;
        }

        public void ApplyDefaults()
        {
            Health = defaultHealth.health;
        }

        [Serializable]
        private sealed class DefaultHealth
        {
            [SerializeField] public float health = 20f;
            [SerializeField] public float maxHealth = 100f;
        }
    }
}