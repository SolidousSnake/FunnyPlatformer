using UnityEngine;
using VContainer.Unity;

namespace Source.Code.Runtime.Services.CameraService
{
    public sealed class CameraService : ITickable
    {
        private readonly Camera _camera;
        private readonly Vector3 _offset;
        private readonly float _smoothing;
        
        private Transform _target;

        public CameraService(Vector3 offset, float smoothing)
        {
            _offset = offset;
            _smoothing = smoothing;
            _camera = Camera.main;
        }
        
        public void SetTarget(Transform target)
        {
            _target = target;
        }

        public void Tick()
        {
            FollowTarget();
        }

        private void FollowTarget()
        {
            if (_target == null)
                return;
            
            var nextPosition = Vector3.Lerp(_camera.transform.position, _target.position + _offset, _smoothing);
            _camera.transform.position = nextPosition;
        }
    }
}
