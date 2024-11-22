using TDS.Service.Coroutine;
using TDS.Service.LevelCompletion;
using TDS.Service.LevelLoading;
using TDS.Service.Mission;
using TDS.Service.PickUp;
using TDS.Service.Restart;
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
            MissionService missionService = ServicesLocator.RegisterMono<MissionService>();
            LevelLoadingService levelLoadingService = new(ServicesLocator.Get<StateMachine>());
            ServicesLocator.Register(levelLoadingService);
            ServicesLocator.Register(new LevelCompletionService(missionService, levelLoadingService));
            ServicesLocator.Register(new RestartService());

            levelLoadingService.Initialize();
            levelLoadingService.EnterFirstLevel();
        }

        public override void Exit() { }

        #endregion
    }
}