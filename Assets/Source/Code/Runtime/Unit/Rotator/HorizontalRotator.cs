using UnityEngine;

namespace Source.Code.Runtime.Unit.Rotator
{
    public sealed class HorizontalRotator
    {
        private readonly Transform _transform;
        private readonly Vector3 _rotationValue;

        private bool _facingRight;

        public HorizontalRotator(Transform context)
        {
            _rotationValue = new Vector3(0f, 180f, 0f);
            _transform = context;
        }
        
        public void Rotate(float direction)
        {
            switch (direction)
            {
                case > 0f when _facingRight:
                case < 0f when !_facingRight:
                    Flip();
                    break;
            }
        }

        private void Flip()
        {
            _facingRight = !_facingRight;
            _transform.Rotate(_rotationValue);
        }
    }
}