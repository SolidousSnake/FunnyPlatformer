using System;
using UnityEngine;

namespace Source.Code.Runtime.MV.Health
{
    public sealed class Health : MonoBehaviour
    {
        private float _maxHealth;
        
        public event Action Depleted;
        public event Action<float> HealthChanged;

        public float Current { get; private set; }

        public void Initialize(float health)
        {
            if(health < 0)
                throw new ArgumentException($"Health must be positive. Received: {health}");

            _maxHealth = Current = health;
        }

        public void ApplyDamage(float damage)
        {
            if (damage < 0)
                throw new ArgumentException($"Damage value must be positive. Received: {damage}");
            
            Current -= damage;

            if (Current <= 0) 
            {
                Current = 0;
                Depleted?.Invoke();
            }
            
            HealthChanged?.Invoke(Current);
        }

        public void ApplyHeal(float health)
        {
            if (health < 0)
                throw new ArgumentException($"Healing value must be positive. Received: {health}");
            
            Current += health;
            
            if (Current > _maxHealth)
                Current = _maxHealth;

            HealthChanged?.Invoke(Current);
        }
    }
}