using System;

namespace Source.Code.Runtime.MV.Health
{
    public sealed class Health
    {
        private readonly float _maxHealth;
        private float _health;

        public Health(float health)
        {
            _maxHealth = _health = health;
        }
        
        public event Action Depleted;
        public event Action<float> HealthChanged;

        public void ApplyDamage(float damage)
        {
            if (damage < 0)
                throw new ArgumentException($"Damage value must be positive. Received: {damage}");
            
            _health -= damage;

            if (_health <= 0) 
            {
                _health = 0;
                Depleted?.Invoke();
            }
            
            HealthChanged?.Invoke(_health);
        }

        public void ApplyHeal(float health)
        {
            if (health < 0)
                throw new ArgumentException($"Healing value must be positive. Received: {health}");
            
            _health += health;
            
            if (_health > _maxHealth)
                _health = _maxHealth;

            HealthChanged?.Invoke(_health);
        }
    }
}