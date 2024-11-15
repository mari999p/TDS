using TDS.Game.Enemy.Base;
using UnityEngine;

namespace TDS.Service.Mission.Conditions
{
    public class KillEnemyMissionCondition : MissionCondition
    {
        #region Variables

        [SerializeField] private EnemyDeath _enemyDeath;

        #endregion

        #region Properties

        public EnemyDeath EnemyDeath => _enemyDeath;

        #endregion
    }
}