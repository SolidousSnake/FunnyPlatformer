using UnityEngine;

namespace Source.Code.Runtime.Unit.Jumper
{
    public sealed class PhysicJump
    {
        private readonly Rigidbody2D _rigidBody;
        private readonly float _jumpHeight;

        public PhysicJump(Rigidbody2D rigidBody, float jumpHeight)
        {
            _rigidBody = rigidBody;
            _jumpHeight = jumpHeight;
        }
        
        public void Jump()
        {
            _rigidBody.AddForce(Vector2.up * _jumpHeight, ForceMode2D.Impulse);
        }
    }
}