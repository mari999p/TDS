using System.Collections;
using UnityEngine;

namespace TDS.Game
{
    public class EnemyAttack: MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private Transform _firePoint;
        [SerializeField] private float _fireRate = 1f; 
        public IEnumerator AutoFire()
        {
            Fire();
            yield return new WaitForSeconds(_fireRate);
        }

        private void Fire()
        {
            Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation); 
        }
    }
}