using UnityEngine;

namespace DinoGame.Animations
{
    /// <summary>
    ///     Wrapper for the player's animator to make it easier to set the animator parameters.
    /// </summary>
    public class PlayerAnimatorWrapper
    {
        private readonly Animator _animator;

        public PlayerAnimatorWrapper(Animator animator)
        {
            _animator = animator;
        }

        public void SetVelocityX(float value)
        {
            _animator.SetFloat(AnimationParam.VelocityX, value);
        }

        public void SetVelocityZ(float value)
        {
            _animator.SetFloat(AnimationParam.VelocityZ, value);
        }

        /// <summary>
        ///     Contains the ids of the animator parameters.
        /// </summary>
        private readonly struct AnimationParam
        {
            internal static readonly int VelocityX = Animator.StringToHash("velocityX");
            internal static readonly int VelocityZ = Animator.StringToHash("velocityZ");
        }
    }
}