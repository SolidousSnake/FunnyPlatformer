using Source.Code.Runtime.MV.Health;
using UnityEngine;

namespace Source.Code.Runtime.Triggers
{
    public sealed class DamageTrigger : MonoBehaviour
    {
        [SerializeField] private float _damage;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Health health))
            {
                health.ApplyDamage(_damage);
            }
        }
    }
}