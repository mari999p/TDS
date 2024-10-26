using UnityEngine;

namespace TDS.Game.Enemy.Base
{
    public abstract class EnemyAttack : EnemyBehaviour
    {
        #region Properties

        protected Transform Target { get; private set; }

        #endregion

        #region Public methods

        public void SetTarget(Transform target)
        {
            Target = target;
        }

        #endregion
    }
}