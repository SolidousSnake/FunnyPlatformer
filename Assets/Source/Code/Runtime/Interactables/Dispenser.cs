using UnityEngine;

namespace Source.Code.Runtime.Interactable
{
    public sealed class Dispenser : MonoBehaviour
    {
        [SerializeField] private float _healingValue;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.TryGetComponent(out Unit.Unit unit))
            {
                unit.Health.ApplyHeal(_healingValue);
            }
        }
    }
}