using Source.Code.Runtime.MV.Health;
using UnityEngine;

namespace Source.Code.Runtime.Interactables
{
    [RequireComponent(typeof(AudioSource))]
    public sealed class Dispenser : MonoBehaviour
    {
        [SerializeField] private float _healingValue;
        [SerializeField] private AudioClip _healingClip;
        [SerializeField] private AudioClip _idleClip;
        [SerializeField] private AudioSource _audioSource;

        private void OnValidate()
        {
            _audioSource ??= GetComponent<AudioSource>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Health health))
            {
                health.ApplyHeal(_healingValue);
                _audioSource.PlayOneShot(_healingClip);
                Debug.Log(other.name);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent(out Health _))
            {
                _audioSource.PlayOneShot(_idleClip);
            }
        }
    }
}