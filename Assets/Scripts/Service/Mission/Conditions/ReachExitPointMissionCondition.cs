using TDS.Game.Common;
using UnityEngine;

namespace TDS.Service.Mission.Conditions
{
    public class ReachExitPointMissionCondition : MissionCondition
    {
        #region Variables

        [SerializeField] private TriggerObserver _observer;
        [SerializeField] private string _nextLevelName;

        #endregion

        #region Properties

        public string NextLevelName => _nextLevelName;

        public TriggerObserver Observer => _observer;

        #endregion
    }
}