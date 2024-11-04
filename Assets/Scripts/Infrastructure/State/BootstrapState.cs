using TDS.Service.Coroutine;
using TDS.Service.SceneLoading;
using TDS.Utils.Log;

namespace TDS.Infrastructure.State
{
    public class BootstrapState : AppState
    {
        #region Public methods

        public override void Enter()
        {
            this.Log();

            ServicesLocator.Register(new SceneLoaderService());
            ServicesLocator.RegisterMono<CoroutineRunner>();

            StateMachine.Enter<LoadGameState>();
        }

        public override void Exit() { }

        #endregion
    }
}