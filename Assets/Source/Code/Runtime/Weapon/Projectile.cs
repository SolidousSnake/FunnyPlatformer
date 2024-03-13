using Source.Code.Runtime.Core.Interfaces;
using UnityEngine;

namespace Source.Code.Runtime.Weapon
{
    [RequireComponent(typeof(Rigidbody2D))]    
    public sealed class Projectile : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidBody;
        [SerializeField] private float _lifeTime;

        private float _damage;
        private float _speed;

        private void OnValidate()
        {
            _rigidBody ??= GetComponent<Rigidbody2D>();
        }

        public void Initialize(float damage, float speed) 
        {
            if(damage < 0)
                throw new System.ArgumentException($"Projectile must have positive damage. Damage equals: {damage}");

            _damage = damage;   
            _speed = speed;
            Destroy(gameObject, _lifeTime);
        }

        private void Update()
        {
            _rigidBody.velocity  = transform.right * _speed;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.TryGetComponent(out IDamageable damageable))
            {
                damageable.Health.ApplyDamage(_damage);
            }
            Destroy(gameObject);
        }
    }
}
