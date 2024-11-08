using TDS.Service.Mission;
using TDS.Utils.Log;

namespace TDS.Infrastructure.State
{
    public class GameState : AppState
    {
        #region Public methods

        public override void Enter()
        {
            this.Log();
            ServicesLocator.Get<MissionService>().Initialize();
        }

        public override void Exit()
        {
            ServicesLocator.Get<MissionService>().Dispose();
        }

        #endregion
    }
}