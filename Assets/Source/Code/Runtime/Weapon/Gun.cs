using Cysharp.Threading.Tasks;
using NTC.Pool;
using UnityEngine;

namespace Source.Code.Runtime.Weapon
{
    public sealed class Gun : MonoBehaviour, IWeapon
    {
        [SerializeField] private Projectile _bulletPrefab;
        [SerializeField] private Transform _muzzle;

        [SerializeField] private float _fireRate;

        [SerializeField] private float _damage;
        [SerializeField] private float _projectileSpeed;

        private bool _canShoot = true;

        public async UniTask Use()
        {
            if (!_canShoot)
                return;

            _canShoot = false;

            Projectile projectile = NightPool.Spawn(_bulletPrefab, _muzzle.position, _muzzle.rotation);
            projectile.Initialize(_damage, _projectileSpeed, _muzzle.right);
            await UniTask.WaitForSeconds(_fireRate);

            _canShoot = true;
        }
    }
}