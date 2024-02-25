using NaughtyAttributes;
using System;
using UnityEngine;

namespace DinoGame.Movement
{
    [CreateAssetMenu(fileName = "New Movement Settings", menuName = "MovementSettings")]
    public class MovementSettings : ScriptableObject
    {
        [Header("Movement")]
        [SerializeField] private float moveSpeed;
        [SerializeField] private float rotationSpeed;
        [SerializeField] private float acceleration;
        [SerializeField] private float accelerationRate;
        [SerializeField] private float decelerationRate;
        [SerializeField] private DefaultMovement defaultMovement;

        [Header("Ground")]
        [SerializeField] private LayerMask layerMask;
        [SerializeField] private float maxDistance;
        [SerializeField] private Vector3 offset;
        [SerializeField] private DefaultGround defaultGround;

        public float MoveSpeed
        {
            get => moveSpeed;
            set => moveSpeed = value < 0 ? 0 : value;
        }

        public float RotationSpeed
        {
            get => rotationSpeed;
            set => rotationSpeed = value < 0 ? 0 : value;
        }

        public float Acceleration
        {
            get => acceleration;
            set => acceleration = value < 0 ? 0 : value;
        }

        public float AccelerationRate
        {
            get => accelerationRate;
            set => accelerationRate = value < 0 ? 0 : value;
        }

        public float DecelerationRate
        {
            get => decelerationRate;
            set => decelerationRate = value < 0 ? 0 : value;
        }

        public LayerMask LayerMask
        {
            get => layerMask;
            set => layerMask = value;
        }

        public float MaxDistance
        {
            get => maxDistance;
            set => maxDistance = value < 0 ? 0 : value;
        }

        public Vector3 Offset
        {
            get => offset;
            set => offset = value;
        }

        [Button]
        public void ApplyDefaults()
        {
            moveSpeed = defaultMovement.moveSpeed;
            rotationSpeed = defaultMovement.rotationSpeed;
            acceleration = defaultMovement.acceleration;
            accelerationRate = defaultMovement.accelerationRate;
            decelerationRate = defaultMovement.decelerationRate;

            layerMask = defaultGround.layerMask;
            maxDistance = defaultGround.maxDistance;
            offset = defaultGround.offset;
        }

        [Serializable]
        private sealed class DefaultMovement
        {
            [SerializeField] public float moveSpeed = 5.0f;
            [SerializeField] public float rotationSpeed = 5.0f;
            [SerializeField] public float acceleration;
            [SerializeField] public float accelerationRate = 1.5f;
            [SerializeField] public float decelerationRate = 2.0f;
        }

        [Serializable]
        private sealed class DefaultGround
        {
            [SerializeField] public LayerMask layerMask;
            [SerializeField] public float maxDistance = 0.2f;
            [SerializeField] public Vector3 offset = new(0, 0.1f, 0);
        }
    }
}