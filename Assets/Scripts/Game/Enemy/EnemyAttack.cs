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

        [Header("Attack settings")]
        [SerializeField] private float _fireRate = 2.0f;
        [SerializeField] private float _delayBeforeBulletSpawn;
        private Coroutine _attackCoroutine;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            _attackCoroutine = StartCoroutine(AttackRoutine());
        }

        private void Update()
        {
            Vector3 direction = _playerTransform.position - transform.position;
            direction.z = 0;
            transform.up = direction.normalized;
        }

        #endregion

        #region Public methods

        public void StopAttacking()
        {
            if (_attackCoroutine != null)
            {
                StopCoroutine(_attackCoroutine);
                _attackCoroutine = null;
            }
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
            StartCoroutine(FireWithAnimationDelay());
        }

        private IEnumerator FireWithAnimationDelay()

        {
            _animation.TriggerAttack();
            yield return new WaitForSeconds(_delayBeforeBulletSpawn);
            Vector2 direction = _playerTransform.position - _spawnPointTransform.position;
            EnemyBullet bullet =
                Instantiate(_bulletPrefab, _spawnPointTransform.position, _spawnPointTransform.rotation);
            bullet.Initialize(direction);
        }

        #endregion
    }
}