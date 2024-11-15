using TDS.Service.Coroutine;
using TDS.Service.Mission;
using TDS.Service.PickUp;
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
            ServicesLocator.RegisterMono<PickUpService>();
            ServicesLocator.RegisterMono<MissionService>();

            StateMachine.Enter<LoadGameState, string>(SceneName.Game);
        }

        public override void Exit() { }

        #endregion
    }
}