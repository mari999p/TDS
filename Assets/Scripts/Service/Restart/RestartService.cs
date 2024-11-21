using TDS.Infrastructure.Locator;
using TDS.Infrastructure.State;
using UnityEngine.SceneManagement;

namespace TDS.Service.Restart
{
    public class RestartService : IService
    {
        #region Public methods

        public void Restart(string sceneName)
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            StateMachine stateMachine = ServicesLocator.Instance.Get<StateMachine>();
            stateMachine.Enter<LoadGameState, string>(currentSceneName);
        }

        #endregion
    }
}