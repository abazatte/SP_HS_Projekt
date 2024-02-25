using NaughtyAttributes;
using System;
using UnityEngine;

namespace DinoGame.Attributes
{
    [CreateAssetMenu(fileName = "New Player Attributes", menuName = "Attributes/Player")]
    public class PlayerAttributes : ScriptableObject
    {
        [Header("Health")]
        [SerializeField] [ProgressBar("Health", "maxHealth", EColor.Red)]
        private float health;
        [SerializeField] private float maxHealth;
        [SerializeField] private DefaultHealth defaultHealth;

        [Header("Hunger")]
        [SerializeField] [ProgressBar("Hunger", "maxHunger", EColor.Green)]
        private float hunger;
        [SerializeField] private float maxHunger;
        [SerializeField] private DefaultHunger defaultHunger;

        [Header("Thirst")]
        [SerializeField] [ProgressBar("Thirst", "maxThirst")]
        private float thirst;
        [SerializeField] private float maxThirst;
        [SerializeField] private DefaultThirst defaultThirst;

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

        public float Hunger
        {
            get => hunger;
            private set => hunger = Mathf.Clamp(value, 0, MaxHunger);
        }

        public float MaxHunger
        {
            get => maxHunger;
            set => maxHunger = value;
        }

        public float Thirst
        {
            get => thirst;
            private set => thirst = Mathf.Clamp(value, 0, MaxThirst);
        }


        public float MaxThirst
        {
            get => maxThirst;
            set => maxThirst = value;
        }

        public void ModifyHealth(float amount)
        {
            Health += amount;
        }

        public void ModifyHunger(float amount)
        {
            Hunger += amount;
        }

        public void ModifyThirst(float amount)
        {
            Thirst += amount;
        }

        [Button]
        public void ApplyDefaults()
        {
            Health = defaultHealth.health;
            MaxHealth = defaultHealth.maxHealth;
            Hunger = defaultHunger.hunger;
            MaxHunger = defaultHunger.maxHunger;
            Thirst = defaultThirst.thirst;
            MaxThirst = defaultThirst.maxThirst;
        }

        [Serializable]
        private sealed class DefaultHealth
        {
            [SerializeField] public float health = 20f;
            [SerializeField] public float maxHealth = 100f;
        }

        [Serializable]
        private sealed class DefaultHunger
        {
            [SerializeField] public float hunger = 20f;
            [SerializeField] public float maxHunger = 100f;
        }

        [Serializable]
        private sealed class DefaultThirst
        {
            [SerializeField] public float thirst = 20f;
            [SerializeField] public float maxThirst = 100f;
        }
    }
}