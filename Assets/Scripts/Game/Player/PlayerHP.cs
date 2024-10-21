using System.Collections;
using TDS.Infrastructure.Locator;
using TDS.Service.SceneLoading;
using UnityEngine;

namespace TDS.Game.Player
{
    public class PlayerHp : MonoBehaviour, IService
    {
        #region Variables

        [Header("HP Settings")]
        [SerializeField] private int _maxHealth = 100;
        [SerializeField] private int _currentHealth;
        [SerializeField] private float _deathDelay = 5f;

        [Header("Animation Settings")]
        [SerializeField] private PlayerAnimation _animation;
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private PlayerAttack _playerAttack;
        private bool _isDead;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            ServicesLocator.Instance.Register(this);
            _currentHealth = _maxHealth;
        }

        private void OnDestroy()
        {
            ServicesLocator.Instance.UnRegister<PlayerHp>();
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

        public void TakeDamage(int damage)
        {
            if (_isDead)
            {
                return;
            }

            _currentHealth -= damage;
            if (_currentHealth <= 0)
            {
                _isDead = true;
                StartCoroutine(Die());
            }
        }

        #endregion

        #region Private methods

        private IEnumerator Die()
        {
            DisablePlayerControls();
            _animation.TriggerDeath();
            yield return new WaitForSeconds(_deathDelay);
            ServicesLocator.Instance.Get<SceneLoaderService>().Load(SceneName.Game);
        }

        private void DisablePlayerControls()
        {
            _playerMovement.enabled = false;
            _playerAttack.enabled = false;
        }

        #endregion
    }
}