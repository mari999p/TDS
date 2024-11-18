using System.Collections;
using TDS.Service.Coroutine;
using TDS.Service.SceneLoading;

namespace TDS.Infrastructure.State
{
    public class LoadGameState : PayloadAppState<string>
    {
        #region Public methods

        public override void Enter(string sceneName)
        {
            SceneLoaderService sceneLoaderService = ServicesLocator.Get<SceneLoaderService>();
            sceneLoaderService.Load(sceneName);

            ServicesLocator.Get<CoroutineRunner>().StartCoroutine(EnterGameWithDelay());
        }

        public override void Exit() { }

        #endregion

        #region Private methods

        private IEnumerator EnterGameWithDelay()
        {
            yield return null;
            StateMachine.Enter<GameState>();
        }

        #endregion
    }
}