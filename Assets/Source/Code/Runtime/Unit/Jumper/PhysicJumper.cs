using Source.Code.Runtime.Triggers;
using UnityEngine;

namespace Source.Code.Runtime.Unit.Jumper
{
    public sealed class PhysicJumper : IJumper
    {
        private readonly Rigidbody2D _rigidBody;
        private readonly float _jumpHeight;
        private readonly SurroundingsTrigger _groundTrigger;

        public PhysicJumper(Rigidbody2D rigidBody, float jumpHeight, SurroundingsTrigger groundTrigger)
        {
            _rigidBody = rigidBody;
            _jumpHeight = jumpHeight;
            _groundTrigger = groundTrigger;
        }
        
        public void Jump()
        {
            if(_groundTrigger.Triggered())
                _rigidBody.AddForce(Vector2.up * _jumpHeight, ForceMode2D.Impulse);
        }
    }
}