using TDS.Game.Common;
using UnityEngine;

namespace TDS.Service.Mission.Conditions
{
    public class ReachExitPointMissionCondition : MissionCondition
    {
        #region Variables

        [SerializeField] private TriggerObserver _observer;

        #endregion

        #region Properties

        public TriggerObserver Observer => _observer;

        #endregion
    }
}