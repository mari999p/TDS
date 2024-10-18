using TDS.Infrastructure.Locator;
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

        #endregion
    }
}