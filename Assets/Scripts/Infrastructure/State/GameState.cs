using TDS.Utils.Log;

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