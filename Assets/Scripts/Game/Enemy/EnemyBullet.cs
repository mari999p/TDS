using System.Collections;
using TDS.Game.Player;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyBullet : Bullet
    {
        protected override void OnPerformCollision(Collider2D collision)
        {
            base.OnPerformCollision(collision);
            if (collision.CompareTag(Tag.Player))
            {
                PlayerHp playerHp = collision.GetComponent<PlayerHp>();
                playerHp.TakeDamage(Damage);
            }

        }

        // #region Variables
        //
        // [Header("Settings")]
        // [SerializeField] private Rigidbody2D _rb;
        // [SerializeField] private float _speed = 10f;
        // [SerializeField] private float _lifetime = 3f;
        // [SerializeField] private int _damage = 10;
        //
        // #endregion
        //
        // #region Unity lifecycle
        //
        // private void Start()
        // {
        //     StartCoroutine(DestroyWithLifetimeDelay());
        // }
        //
        // private void OnTriggerEnter2D(Collider2D collision)
        // {
        //     OnPerformCollision(collision);
        //
        //     Destroy(gameObject);
        // }
        //
        // #endregion
        //
        // #region Public methods
        //
        // public void Initialize(Vector2 direction)
        // {
        //     _rb.velocity = direction.normalized * _speed;
        // }
        //
        // #endregion
        //
        // #region Private methods
        //
        // private IEnumerator DestroyWithLifetimeDelay()
        // {
        //     yield return new WaitForSeconds(_lifetime);
        //     Destroy(gameObject);
        // }

        // #endregion
    }
}