using TDS.Game.Common;
using UnityEngine;

namespace TDS.Service.Mission.Conditions
{
    public class KillEnemyMissionCondition : MissionCondition
    {
        #region Variables

        [SerializeField] private UnitHp _enemyUnitHp;

        #endregion
    }
}