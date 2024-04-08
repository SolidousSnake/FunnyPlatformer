using System;
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

        public event Action Moved;
        public event Action Stopped;
        
        public void Move(float direction)
        {
            var scaledSpeed = _movementSpeed * direction;
            var movementVector = new Vector2(scaledSpeed, _rigidBody.velocity.y);

           _rigidBody.velocity = movementVector;
           Moved?.Invoke();
        }

        public void Stop()
        {
            _rigidBody.angularVelocity = 0;
            _rigidBody.velocity = new Vector2(0, _rigidBody.velocity.y);
            Stopped?.Invoke();
        }
    }
}