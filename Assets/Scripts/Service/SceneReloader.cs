using System.Collections;
using TDS.Infrastructure.Locator;
using TDS.Service.SceneLoading;
using UnityEngine;

namespace TDS.Service
{
    public class SceneReloader : MonoBehaviour
    {
        #region Variables

        [SerializeField] private float _reloadDelay = 5f;

        #endregion

        #region Public methods

        public void ReloadScene()
        {
            StartCoroutine(ReloadSceneCoroutine());
        }

        #endregion

        #region Private methods

        private IEnumerator ReloadSceneCoroutine()
        {
            yield return new WaitForSeconds(_reloadDelay);
            ServicesLocator.Instance.Get<SceneLoaderService>().Load(SceneName.Game);
        }

        #endregion
    }
}