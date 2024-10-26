using UnityEngine;

namespace TDS.Game.Enemy.Base
{
    public abstract class EnemyMovement : EnemyBehaviour
    {
        #region Public methods

        public abstract void SetTarget(Transform target);

        #endregion
    }
}