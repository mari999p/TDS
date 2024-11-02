using System.Collections;
using TDS.Game.Common;
using UnityEngine;

namespace TDS.Game.Player
{
    public class Bullet : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private float _speed = 10f;
        [SerializeField] private float _lifetime = 3f;
        [SerializeField] private int _damage = 2;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            _rb.velocity = transform.up * _speed;

            StartCoroutine(DestroyWithLifetimeDelay());
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out IDamageable hp))
            {
                hp.ApplyDamage(_damage);
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