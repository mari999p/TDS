using System.Collections;
using TDS.Game.Player;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyBullet : MonoBehaviour
    {
        #region Variables

        [Header("Settings")]
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private float _speed = 10f;
        [SerializeField] private float _lifetime = 3f;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            StartCoroutine(DestroyWithLifetimeDelay());
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag(Tag.Player))
            {
                PlayerHp playerHp = collision.GetComponent<PlayerHp>();
                playerHp.TakeDamage(10);
            }

            Destroy(gameObject);
        }

        #endregion

        #region Public methods

        public void Initialize(Vector2 direction)
        {
            _rb.velocity = direction.normalized * _speed;
        }

        #endregion

        #region Private methods

        private IEnumerator DestroyWithLifetimeDelay()
        {
            yield return new WaitForSeconds(_lifetime);
            Destroy(gameObject);
        }

        #endregion
    }
}