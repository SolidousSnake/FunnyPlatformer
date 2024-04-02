using Source.Code.Runtime.Triggers;
using UnityEngine;

namespace Source.Code.Runtime.Unit.Mover
{
    public sealed class PhysicsMovement
    {
         private readonly Rigidbody2D _rigidBody;
         private readonly float _movementSpeed;
         private readonly SurroundingsTrigger _wallTrigger;
         
        public PhysicsMovement(Rigidbody2D rigidBody, float movementSpeed, SurroundingsTrigger wallTrigger)
        {
            _rigidBody = rigidBody;
            _movementSpeed = movementSpeed;
            _wallTrigger = wallTrigger;
        }
        
        public void Move(float direction)
        {
            if (_wallTrigger.Triggered())
                return;
            
            var scaledSpeed = _movementSpeed * direction;
            var movementVector = new Vector2(scaledSpeed, _rigidBody.velocity.y);

           _rigidBody.velocity = movementVector;
        }

        public void ResetVelocity()
        {
            _rigidBody.angularVelocity = 0;
            _rigidBody.velocity = new Vector2(0, _rigidBody.velocity.y);
        }
    }
}