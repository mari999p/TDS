using TDS.Game;
using TDS.Service.Mission.Conditions;
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

        private void ObserverEnteredCallback(Collider2D col)
        {
            if (col.CompareTag(Tag.Player))
            {
                InvokeCompletion();
            }
        }

        #endregion
    }
}