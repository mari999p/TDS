using System;
using UnityEngine;

namespace TDS.Game.Common
{
    public class BossHp : MonoBehaviour, IDamageable
    {
        #region Variables

        [SerializeField] private UnitHp _hp;

        #endregion

        #region Events

        public event Action OnBossDefeated;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            _hp.OnChanged += CheckIfDefeated;
        }

        #endregion

        #region IDamageable

        public void ApplyDamage(int damage)
        {
            _hp.ApplyDamage(damage);
        }

        #endregion

        #region Private methods

        private void CheckIfDefeated(int currentHp)
        {
            if (currentHp <= 0)
            {
                OnBossDefeated?.Invoke();
                // CompleteLevel();
            }
        }

        #endregion

        // private void CompleteLevel()
        // {
        //     SceneLoaderService sceneLoaderService = ServicesLocator.Instance.Get<SceneLoaderService>();
        //     sceneLoaderService.Load(SceneName.NextLevel);
        // }
    }
}