using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Source.Code.Runtime.Weapon
{
    public sealed class MachineGun : MonoBehaviour
    {
        [SerializeField] private Projectile _bulletPrefab;
        [SerializeField] private Transform _barrel;

        [SerializeField] private float _fireRate;

        [SerializeField] private float _damage;
        [SerializeField] private float _projectileSpeed;

        private bool _canShoot = true;

        public async UniTaskVoid Shoot()
        {
            if (!_canShoot)
                return;

            _canShoot = false;

            Projectile projectile = Instantiate(_bulletPrefab, _barrel.position, _barrel.rotation);
            projectile.Initialize(_damage, _projectileSpeed);
            await UniTask.WaitForSeconds(_fireRate);

            _canShoot = true;
        }
    }
}