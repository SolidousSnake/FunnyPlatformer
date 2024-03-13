using UnityEngine;

namespace Source.Code.Runtime.Unit.GroundCheck
{
    public sealed class GroundCheck : MonoBehaviour
    {
        [SerializeField] private float _radius;
        [SerializeField] private LayerMask _groundLayer;

        public bool OnGround()
        {
            return Physics2D.OverlapCircle(
                transform.position
                , _radius
                , _groundLayer);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _radius);
        }
    }
}