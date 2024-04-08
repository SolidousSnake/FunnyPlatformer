using Source.Code.Runtime.Core.Utils;
using UnityEngine;

namespace Source.Code.Runtime.Unit.Player
{
    public sealed class PlayerAnimator
    {
        private readonly Animator _animator;

        private readonly int _walkHash = Animator.StringToHash(Constants.Animation.Move);
        private readonly int _jumpHash = Animator.StringToHash(Constants.Animation.Jump);

        public PlayerAnimator(Animator animator)
        {
            _animator = animator;
        }
        
        public void PlayWalk() => _animator.SetBool(_walkHash, true);
        public void PlayJump() => _animator.SetBool(_jumpHash, true);
        public void StopWalk() => _animator.SetBool(_walkHash, false);
        public void StopJump() => _animator.SetBool(_jumpHash, false);
    }
}