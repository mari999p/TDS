using System;
using UnityEngine;

namespace TDS.Game.Enemy.Base
{
    public class EnemyAnimation : MonoBehaviour
    {
        #region Variables

        private static readonly int Attack = Animator.StringToHash("attack");
        private static readonly int Dead = Animator.StringToHash("dead");
        private static readonly int Speed = Animator.StringToHash("speed");

        [SerializeField] private Animator _animator;

        #endregion

        #region Events

        public event Action OnAttackHit;

        #endregion

        #region Public methods

        public void PlayAttack()
        {
            _animator.SetTrigger(Attack);
        }

        public void PlayDeath()
        {
            _animator.SetTrigger(Dead);
        }

        public void SetSpeed(float value)
        {
            _animator.SetFloat(Speed, value);
        }

        #endregion

        #region Private methods

        private void AttackHit()
        {
            OnAttackHit?.Invoke();
        }

        #endregion
    }
}