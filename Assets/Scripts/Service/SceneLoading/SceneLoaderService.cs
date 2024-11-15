using System.Collections;
using TDS.Infrastructure.Locator;
using TDS.Infrastructure.State;
using TDS.Service.Coroutine;
using UnityEngine.SceneManagement;

namespace TDS.Service.SceneLoading
{
    public class SceneLoaderService : IService
    {
        #region Public methods

        public void Load(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

        public void LoadAsync(string sceneName) { }

        public void RetrySceneWithDelay(string sceneName)
        {
            ServicesLocator.Instance.Get<CoroutineRunner>().StartCoroutine(RetryLevelWithDelay(sceneName));
        }

        #endregion

        #region Private methods

        private IEnumerator RetryLevelWithDelay(string sceneName)
        {
            yield return null;
            Load(sceneName);
            ServicesLocator.Instance.Get<StateMachine>().Enter<GameState>();
        }

        #endregion
    }
}