using TDS.Game.Enemy.Base;
using TDS.Utils.Log;
using UnityEngine;

namespace TDS.Infrastructure.State
{
    public class GameState : AppState
    {
     
        #region Public methods

        public override void Enter()
        {
            this.Log();
        }

        public override void Exit() { }

        #endregion
    }
}