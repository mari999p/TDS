using TDS.Game.Common;
using TDS.Infrastructure.Locator;
using TDS.Service.SceneLoading;
using UnityEngine;

namespace TDS.Game.Player
{
    public class PlayerHp : MonoBehaviour, IDamageable
    {
        #region Variables

        [Header("HP Settings")]
        [SerializeField] private int _maxHealth = 100;
        [SerializeField] private int _currentHealth;

        [Header("Animation Settings")]
        [SerializeField] private PlayerAnimation _animation;
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private PlayerAttack _playerAttack;

        private bool _isDead;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            _currentHealth = _maxHealth;
        }

        #endregion

        #region Public methods

        public void Heal(int amount)
        {
            if (!_isDead)
            {
                _currentHealth = Mathf.Min(_currentHealth + amount, _maxHealth);
            }
        }

        private void TakeDamage(int damage)
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
            _isDead = true;
            DisablePlayerControls();
            // ServicesLocator.Instance.Get<SceneLoaderService>().ReloadCurrentScene(5);
            _animation.TriggerDeath();
        }

        private void DisablePlayerControls()
        {
            _playerMovement.enabled = false;
            _playerAttack.enabled = false;
        }

        #endregion

        public void ApplyDamage(int damage)
        {
            TakeDamage(damage);
        }
    }
}