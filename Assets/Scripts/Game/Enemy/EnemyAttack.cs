using System.Collections;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyAttack: MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private Transform _playerTransform;
        [SerializeField] private EnemyAnimation _animation;

        [Header("Settings")]
        [SerializeField] private EnemyBullet _bulletPrefab;
        [SerializeField] private Transform _spawnPointTransform;
        [SerializeField] private float _fireRate = 2.0f;
        

        private Coroutine _attackCoroutine;
        
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
            EnemyBullet bullet = Instantiate(_bulletPrefab, _spawnPointTransform.position, _spawnPointTransform.rotation);
            bullet.Initialize(direction);
        }

    }
}