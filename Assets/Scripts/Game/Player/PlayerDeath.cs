using System;
using TDS.Game.Common;
using UnityEngine;

namespace TDS.Game.Player
{
    public class PlayerDeath : MonoBehaviour
    {
        #region Variables

        [SerializeField] private UnitHp _hp;
        [SerializeField] private int _currentHealth;
        [SerializeField] private PlayerMovement _movement;
        [SerializeField] private PlayerAttack _attack;
        [SerializeField] private PlayerAnimation _animation;

        #endregion

        #region Events

        public event Action OnDeathOccurred;

        #endregion

        #region Properties

        public bool IsDead { get; private set; }

        #endregion

        #region Unity lifecycle

        private void OnEnable()
        {
            _hp.OnChanged += HpChangedCallback;
        }

        private void OnDisable()
        {
            _hp.OnChanged -= HpChangedCallback;
        }

        #endregion

        #region Public methods

        public void Heal(int healAmount)
        {
            if (IsDead)
            {
                return;
            }

            _hp.Change(healAmount);
        }

        #endregion

        #region Private methods

        private void Die()
        {
            IsDead = true;
            _animation.TriggerDeath();
            _movement.Deactivate();
            _attack.Deactivate();
            OnDeathOccurred?.Invoke();
        }

        private void HpChangedCallback(int hp)
        {
            if (hp > 0 || IsDead)
            {
                return;
            }

            Die();
        }

        #endregion

      
    }
}