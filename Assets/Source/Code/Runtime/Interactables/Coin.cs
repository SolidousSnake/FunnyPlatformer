using NTC.Pool;
using Source.Code.Runtime.Unit;
using UnityEngine;

namespace Source.Code.Runtime.Interactables
{
    public sealed class Coin : MonoBehaviour
    {
        [SerializeField] private int _amount;
        [SerializeField] private ParticleSystem _particleSystemPrefab;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out PlayerFacade player))
            {
                player.Wallet.AddCoin(_amount);
                NightPool.Spawn(_particleSystemPrefab, transform.position, Quaternion.identity).DespawnOnComplete();
                Destroy(gameObject);
            }
        }
    }
}