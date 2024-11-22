using System.Collections;
using Lean.Pool;
using TDS.Game.Common;
using UnityEngine;

namespace TDS.Game.Player
{
    public class Bullet : MonoBehaviour, IPoolable
    {
        #region Variables

        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private float _speed = 10f;
        [SerializeField] private float _lifetime = 3f;
        [SerializeField] private int _damage = 2;

        #endregion

        #region Unity lifecycle

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out UnitHp hp))
            {
                hp.Change(-_damage);
            }

            LeanPool.Despawn(gameObject);
        }

        #endregion

        #region IPoolable

        public void OnSpawn()
        {
            _rb.velocity = transform.up * _speed;

            StartCoroutine(DestroyWithLifetimeDelay());
        }

        public void OnDespawn()
        {
            _rb.velocity = Vector2.zero;
        }

        #endregion

        #region Private methods

        private IEnumerator DestroyWithLifetimeDelay()
        {
            yield return new WaitForSeconds(_lifetime);

            LeanPool.Despawn(gameObject);
        }

        #endregion
    }
}