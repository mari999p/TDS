using TDS.Infrastructure.Locator;
using TDS.Infrastructure.State;
using TDS.Service.SceneLoading;

namespace TDS.Service.GameOver
{
    public class GameOverService : IService
    {
        #region Variables

        private readonly StateMachine _stateMachine;

        #endregion

        #region Setup/Teardown

        public GameOverService(StateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        #endregion

        #region Public methods

        public void ShowGameOverScreen()
        {
            _stateMachine.Enter<LoadGameState, string>(SceneName.GameOverSceneName);
        }

        #endregion
    }
}