using UnityEngine;

namespace TDS.Infrastructure.State
{
    public class GameState : AppState
    {
        #region Public methods

        public override void Enter() { }

        public override void Exit()
        {
            Debug.Log("GameState Enter");
        }

        #endregion
    }
}