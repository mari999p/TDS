using TDS.Game.Enemy;
using UnityEngine;

namespace TDS.Game.UI
{
    public class EnemyHp : MonoBehaviour
    {
        #region Variables

        [Header("HP Settings")]
        [SerializeField] private int _maxHealth = 100;
        [SerializeField] private int _currentHealth;

        [Header("Animation Settings")]
        [SerializeField] private EnemyAnimation _animation;
        [SerializeField] private EnemyAttack _enemyAttack;
        private bool _isDead;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            _currentHealth = _maxHealth;
        }

        #endregion

        #region Public methods

        public void TakeDamage(int damage)
        {
            if (_isDead)
            {
                return;
            }

            _currentHealth -= damage;
            if (_currentHealth <= 0)
            {
                Die();
            }
        }

        #endregion

        #region Private methods

        private void Die()
        {
            if (_isDead)
            {
                return;
            }

            _isDead = true;
            _enemyAttack.enabled = false;
            _enemyAttack.StopAttacking();
            _animation.TriggerDeath();
        }

        #endregion
    }
}