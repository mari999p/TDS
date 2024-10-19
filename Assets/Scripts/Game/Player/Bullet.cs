using System.Collections;
using TDS.Game.UI;
using UnityEngine;

namespace TDS.Game.Player
{
    public class Bullet : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private float _speed = 50f;
        [SerializeField] private float _lifetime = 3f;
        [SerializeField] private EnemyHp _enemyHp;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            _rb.velocity = transform.up * _speed;
            StartCoroutine(DestroyWithLifetimeDelay());
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Enemy"))
            {
                EnemyHp playerHp = collision.GetComponent<EnemyHp>();
                if (playerHp != null)
                {
                    playerHp.TakeDamage(10);
                }
            }
            
            Destroy(gameObject);
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