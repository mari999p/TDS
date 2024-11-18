using TDS.Game;
using TDS.Infrastructure.Locator;
using TDS.Service.Mission.Conditions;
using TDS.Service.SceneLoading;
using UnityEngine;

namespace TDS.Service.Mission.ConcreteMissions
{
    public class ReachExitPointMission : Mission<ReachExitPointMissionCondition>
    {
        #region Protected methods

        protected override void OnBegin()
        {
            base.OnBegin();

            Condition.Observer.OnEntered += ObserverEnteredCallback;
        }

        protected override void OnStop()
        {
            base.OnStop();

            Condition.Observer.OnEntered -= ObserverEnteredCallback;
        }

        #endregion

        #region Private methods

        private void LoadNextLevel()
        {
            SceneLoaderService sceneLoaderService = ServicesLocator.Instance.Get<SceneLoaderService>();
            sceneLoaderService.Load(Condition.NextLevelName);
        }

        private void ObserverEnteredCallback(Collider2D col)
        {
            if (col.CompareTag(Tag.Player))
            {
                InvokeCompletion();
                LoadNextLevel();
            }
        }

        #endregion
    }
}