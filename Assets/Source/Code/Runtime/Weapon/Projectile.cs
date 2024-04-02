using System;
using NTC.Pool;
using Source.Code.Runtime.MV.Health;
using UnityEngine;

namespace Source.Code.Runtime.Weapon
{
    [RequireComponent(typeof(Rigidbody2D))]    
    public sealed class Projectile : MonoBehaviour, IDespawnable
    {
        [SerializeField] private Rigidbody2D _rigidBody;

        private float _damage;
        
        private void OnValidate()
        {
            _rigidBody ??= GetComponent<Rigidbody2D>();
        }

        public void Initialize(float damage, float speed, Vector2 direction) 
        {
            if(damage < 0)
                throw new ArgumentException($"Projectile must have positive damage. Damage equals: {damage}");

            _damage = damage;

            _rigidBody.velocity = speed * direction;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.TryGetComponent(out Health health))
                health.ApplyDamage(_damage);
         
            NightPool.Despawn(gameObject);
        }
        
        public void OnDespawn()
        {
            _rigidBody.angularVelocity = 0;
        }
    }
}
