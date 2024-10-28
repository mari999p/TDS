using TDS.Game.Common;
using UnityEngine;

namespace TDS.Game
{
    public class ExplosiveBarrel: MonoBehaviour
    {
        [SerializeField] private float _explosionRadius = 5f;
        [SerializeField] private int _explosionDamage = 10;
        [SerializeField] private GameObject _explosionEffect;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(Tag.PlayerBullet))
            {
                Explode();
                Destroy(other.gameObject);
            }
                
        }

        private void Explode()
        {
            if (_explosionEffect != null)
            {
                Instantiate(_explosionEffect, transform.position, Quaternion.identity);
            }
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, _explosionRadius);
            foreach (Collider2D hitCollider in hitColliders)
            {
                if (hitCollider.TryGetComponent(out IDamageable damageable))
                {
                    damageable.ApplyDamage(_explosionDamage);
                }
                Destroy(gameObject);
            }
        }
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _explosionRadius);
        }
    }
}