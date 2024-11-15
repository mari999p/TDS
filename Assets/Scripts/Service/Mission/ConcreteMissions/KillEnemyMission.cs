using TDS.Service.Mission.Conditions;

namespace TDS.Service.Mission.ConcreteMissions
{
    public class KillEnemyMission : Mission<KillEnemyMissionCondition>
    {
        #region Protected methods

        protected override void OnBegin()
        {
            base.OnBegin();

            Condition.EnemyDeath.OnHappened += DeathHappenedCallback;
        }

        protected override void OnStop()
        {
            base.OnStop();

            Condition.EnemyDeath.OnHappened -= DeathHappenedCallback;
        }

        #endregion

        #region Private methods

        private void DeathHappenedCallback()
        {
            InvokeCompletion();
        }

        #endregion
    }
}