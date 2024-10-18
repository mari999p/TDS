using System.Collections;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyBullet: MonoBehaviour
    {[SerializeField] private Rigidbody2D _rb;
        [SerializeField] private float _speed = 10f;
        [SerializeField] private float _lifetime = 3f;

        private void Start()
        {
            StartCoroutine(DestroyWithLifetimeDelay());
        }
        public void Initialize(Vector2 direction)
        {
            _rb.velocity = direction.normalized * _speed;
        }
        private IEnumerator DestroyWithLifetimeDelay()
        {
            yield return new WaitForSeconds(_lifetime);
            Destroy(gameObject);
        }
        
        
    }
}