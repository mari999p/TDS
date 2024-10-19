using System.Collections;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyAttack : MonoBehaviour
    {
        #region Variables

        [Header("Components")]
        [SerializeField] private Transform _playerTransform;
        [SerializeField] private EnemyAnimation _animation;

        [Header("Settings")]
        [SerializeField] private EnemyBullet _bulletPrefab;
        [SerializeField] private Transform _spawnPointTransform;
        [SerializeField] private float _fireRate = 2.0f;
        private Coroutine _attackCoroutine;
        #endregion

        #region Unity lifecycle

        private void Start()
        {
            _attackCoroutine = StartCoroutine(AttackRoutine());
        }
        public void StopAttacking()
        {
            if (_attackCoroutine != null)
            {
                StopCoroutine(_attackCoroutine);
                _attackCoroutine = null;
            }
        }

        private void Update()
        {
            Vector3 direction = _playerTransform.position - transform.position;
            direction.z = 0;
            transform.up = direction.normalized;
        }

        #endregion

        #region Private methods

        private IEnumerator AttackRoutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(_fireRate);
                Fire();
            }
        }

        private void Fire()
        {
            _animation.TriggerAttack();
            Vector2 direction = _playerTransform.position - _spawnPointTransform.position;
            EnemyBullet bullet =
                Instantiate(_bulletPrefab, _spawnPointTransform.position, _spawnPointTransform.rotation);
            bullet.Initialize(direction);
        }

        #endregion
    }
}