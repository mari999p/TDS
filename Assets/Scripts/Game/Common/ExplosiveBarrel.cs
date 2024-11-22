using Lean.Pool;
using UnityEngine;

namespace TDS.Game.Common
{
    public class ExplosiveBarrel : MonoBehaviour, IDamageable,IPoolable
    {
        #region Variables

        [Header("Settings Sprite")]
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Sprite _crackedBarrel;
        [SerializeField] private Sprite _heavilyCrackedBarrel;

        [Header("Settings HP")]
        [SerializeField] private int _hitPoints = 3;

        [Header("Barrel Settings")]
        [SerializeField] private float _explosionRadius = 5f;
        [SerializeField] private int _explosionDamage = 10;
        [SerializeField] private GameObject _explosionEffect;
        [SerializeField] private GameObject _burningEffect;
        [SerializeField] private LayerMask _layerMask;

        #endregion

        #region Unity lifecycle

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _explosionRadius);
        }

        #endregion

        #region IDamageable

        public void ApplyDamage(int damage)
        {
            if (_hitPoints > 0)
            {
                _hitPoints--;
                UpdateSprite();
            }

            if (_hitPoints <= 0)
            {
                Explode();
            }
        }

        #endregion

        #region Private methods

        private void Explode()
        {
            if (_explosionEffect != null)
            {
                LeanPool.Spawn(_explosionEffect, transform.position, Quaternion.identity);
            }

            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, _explosionRadius, _layerMask);
            foreach (Collider2D hitCollider in hitColliders)
            {
                if (hitCollider.gameObject == gameObject)
                {
                    continue;
                }

                if (hitCollider.TryGetComponent(out IDamageable damageable))
                {
                    damageable.ApplyDamage(_explosionDamage);
                }
            }

            if (_burningEffect != null)
            {
                LeanPool.Spawn(_burningEffect, transform.position, Quaternion.identity);
            }

            Destroy(this);
        }

        private void UpdateSprite()
        {
            if (_hitPoints == 2)
            {
                _spriteRenderer.sprite = _crackedBarrel;
            }
            else if (_hitPoints == 1)
            {
                _spriteRenderer.sprite = _heavilyCrackedBarrel;
            }
        }

        #endregion

        public void OnSpawn()
        {
            throw new System.NotImplementedException();
        }

        public void OnDespawn()
        {
            throw new System.NotImplementedException();
        }
    }
}