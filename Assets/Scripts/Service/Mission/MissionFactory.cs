using TDS.Service.Mission.ConcreteMissions;
using TDS.Service.Mission.Conditions;

namespace TDS.Service.Mission
{
    public class MissionFactory
    {
        #region Public methods

        public Mission Create(MissionCondition condition)
        {
            if (condition is ReachExitPointMissionCondition reachExitPointMissionCondition)
            {
                ReachExitPointMission reachExitPointMission = new();
                reachExitPointMission.SetCondition(reachExitPointMissionCondition);
                return reachExitPointMission;
            }

            if (condition is KillEnemyMissionCondition killEnemyMissionCondition)
            {
                KillEnemyMission killEnemyMission = new();
                killEnemyMission.SetCondition(killEnemyMissionCondition);
                return killEnemyMission;
            }

            return null;
        }

        #endregion
    }
}