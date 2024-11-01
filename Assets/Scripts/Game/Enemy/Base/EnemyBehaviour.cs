using UnityEngine;

namespace TDS.Game.Enemy.Base
{
    public abstract class EnemyBehaviour : MonoBehaviour
    {
        #region Public methods

        public void Activate()
        {
            enabled = true;
        }

        public void Deactivate()
        {
            enabled = false;
        }

        #endregion

        protected virtual void DoStm(){}
    }
}