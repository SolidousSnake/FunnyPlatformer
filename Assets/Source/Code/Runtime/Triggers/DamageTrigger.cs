using UnityEngine;

namespace Source.Code.Runtime.Triggers
{
    public sealed class DamageTrigger : MonoBehaviour
    {
        [SerializeField] private float _damage;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Unit.Unit unit))
            {
                unit.Health.ApplyDamage(_damage);
            }
        }
    }
}