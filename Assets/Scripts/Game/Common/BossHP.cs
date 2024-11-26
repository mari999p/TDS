using System;
using UnityEngine;

namespace TDS.Game.Common
{
    public class BossHp : MonoBehaviour, IDamageable
    {
        #region Variables

        public UnitHp hp;

        #endregion

        #region Events

        public event Action OnBossDefeated;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            hp.OnChanged += CheckIfDefeated;
        }

        #endregion

        #region IDamageable

        public void ApplyDamage(int damage)
        {
            hp.ApplyDamage(damage);
        }

        #endregion

        #region Private methods

        private void CheckIfDefeated(int currentHp)
        {
            if (currentHp <= 0)
            {
                OnBossDefeated?.Invoke();
            }
        }

        #endregion
    }
}