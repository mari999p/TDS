using System;
using TDS.Infrastructure.Locator;
using TDS.Infrastructure.State;
using TDS.Service.SceneLoading;
using UnityEngine;

namespace TDS.Game.Common
{
    public class BossHp : MonoBehaviour, IDamageable
    {
        [SerializeField] private UnitHp _hp;
        public event Action OnBossDefeated; 

        private void Awake()
        {
            _hp.OnChanged += CheckIfDefeated;
            
        }

        private void CheckIfDefeated(int currentHp)
        {
            if (currentHp <= 0)
            {
                OnBossDefeated?.Invoke();
                CompleteLevel();
            }
        }

        private void CompleteLevel()
        {
            SceneLoaderService sceneLoaderService = ServicesLocator.Instance.Get<SceneLoaderService>();
            sceneLoaderService.Load(SceneName.NextLevel);
        }
        

        public void ApplyDamage(int damage)
        {
            _hp.ApplyDamage(damage); 
        }
    }
}