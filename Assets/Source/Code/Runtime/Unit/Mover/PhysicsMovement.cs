using UnityEngine;

namespace Source.Code.Runtime.Unit.Mover
{
    public sealed class PhysicsMovement
    {
         private readonly Rigidbody2D _rigidBody;
         private readonly float _movementSpeed;

        public PhysicsMovement(Rigidbody2D rigidBody, float movementSpeed)
        {
            _rigidBody = rigidBody;
            _movementSpeed = movementSpeed;
        }
        
        public void Move(float axisValue)
        {
            var scaledSpeed = _movementSpeed * axisValue;
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