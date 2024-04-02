using System;
using NaughtyAttributes;
using UnityEngine;

namespace Source.Code.Runtime.Unit.Enemy.Vision
{
    [RequireComponent(typeof(PolygonCollider2D))]
    public sealed class FieldOfView : MonoBehaviour, IVision
    {
        [SerializeField] private PolygonCollider2D _trigger;
        [Layer] [SerializeField] private int _playerLayer;
        
        public event Action PlayerSighted;
        public event Action PlayerFleed;

        private void OnValidate()
        {
            _trigger ??= GetComponent<PolygonCollider2D>();
            _trigger.isTrigger = true;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.gameObject.layer == _playerLayer)
                PlayerSighted?.Invoke();
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if(other.gameObject.layer == _playerLayer)
                PlayerFleed?.Invoke();
        }
    }
}