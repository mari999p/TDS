using TDS.Game.Enemy.Base;
using TDS.Game.Player;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public class RangeEnemyAttack : EnemyAttack
    {
        #region Variables

        [Header("Settings")]
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private Transform _spawnPointTransform;
        [SerializeField] private float _fireRate = 1f;

        private float _timer;

        #endregion

        #region Unity lifecycle

        private void Update()
        {
            if (Target == null)
            {
                return;
            }

            Rotate();
            TryAttack();
        }

        #endregion

        #region Private methods

        private void Fire()
        {
            // _animation.TriggerAttack();
            Instantiate(_bulletPrefab, _spawnPointTransform.position, _spawnPointTransform.rotation);
        }

        private void Rotate()
        {
            transform.up = Target.position - transform.position;
        }

        private void TryAttack()
        {
            _timer -= Time.deltaTime;
            if (_timer > 0)
            {
                return;
            }

            Fire();
            _timer = _fireRate;
        }

        #endregion
    }
}