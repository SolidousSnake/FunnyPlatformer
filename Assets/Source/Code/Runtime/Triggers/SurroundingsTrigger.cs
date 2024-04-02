using System;
using UnityEngine;

namespace Source.Code.Runtime.Triggers
{
    public sealed class SurroundingsTrigger : MonoBehaviour
    {
        [SerializeField] private float _radius;
        [SerializeField] private LayerMask _objectLayer;

        public bool Triggered()
        {
            return Physics2D.OverlapCircle(
                transform.position
                , _radius
                , _objectLayer);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _radius);
        }
    }
}