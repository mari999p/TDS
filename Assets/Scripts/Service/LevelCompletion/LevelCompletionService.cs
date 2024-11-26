using TDS.Infrastructure.Locator;
using TDS.Service.GameOver;
using TDS.Service.LevelLoading;
using TDS.Service.Mission;
using TDS.Utils.Log;

namespace TDS.Service.LevelCompletion
{
    public class LevelCompletionService : IService
    {
        #region Variables

        private readonly GameOverService _gameOverService;

        private readonly LevelLoadingService _levelLoadingService;

        private readonly MissionService _missionService;

        #endregion

        #region Setup/Teardown

        public LevelCompletionService(MissionService missionService, LevelLoadingService levelLoadingService,
            GameOverService gameOverService)
        {
            _missionService = missionService;
            _levelLoadingService = levelLoadingService;
            _gameOverService = gameOverService;
        }

        #endregion

        #region Public methods

        public void Dispose()
        {
            _missionService.OnCompleted -= MissionCompletedCallback;
        }

        public void Initialize()
        {
            _missionService.OnCompleted += MissionCompletedCallback;
        }

        #endregion

        #region Private methods

        private void MissionCompletedCallback()
        {
            if (_levelLoadingService.HasNextLevel())
            {
                _levelLoadingService.EnterNextLevel();
            }
            else
            {
                _gameOverService.ShowGameOverScreen();
                // this.Error("GAME OVER!");
            }
        }

        #endregion
    }
}