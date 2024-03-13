using TMPro;
using UnityEngine;

namespace Source.Code.Runtime.MV.Health
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public sealed class HealthView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _healthLabel;
        [SerializeField] private string _prefix = "HP:";
        [SerializeField] private string _suffix = " HP";
        
        private Health _health;
        
        public void Initialize(Health health)
        {
            _health = health;
            _health.HealthChanged += SetAmount;
        }

        private void SetAmount(float amount)
        {
            _healthLabel.text = _prefix + $"{amount}" + _suffix;
        }

        private void OnDestroy()
        {
            _health.HealthChanged -= SetAmount;
        }
    }
}