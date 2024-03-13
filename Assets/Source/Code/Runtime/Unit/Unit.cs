using Source.Code.Runtime.Core.Interfaces;
using Source.Code.Runtime.MV.Health;
using UnityEngine;

namespace Source.Code.Runtime.Unit
{
    public abstract class Unit : MonoBehaviour, IDamageable
    {
        public Health Health { get; private set; }

        public void Initialize(float health)
        {
            Health = new Health(health);
        }
    }
}