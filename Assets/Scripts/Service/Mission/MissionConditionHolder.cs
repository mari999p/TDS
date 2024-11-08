using UnityEngine;

namespace TDS.Service.Mission
{
    public class MissionConditionHolder : MonoBehaviour
    {
        #region Variables

        [SerializeField] private MissionCondition _missionCondition;

        #endregion

        #region Properties

        public MissionCondition MissionCondition => _missionCondition;

        #endregion
    }
}