using TDS.Infrastructure.Locator;
using TDS.Service.SceneLoading;
using UnityEngine;

namespace TDS.Game.Common
{
    public class LevelTransitionTrigger : MonoBehaviour
    {
        #region Variables

        [SerializeField] private string _nextSceneName;

        #endregion

        #region Unity lifecycle

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(Tag.Player))
            {
                SceneLoaderService sceneLoaderService = ServicesLocator.Instance.Get<SceneLoaderService>();
                sceneLoaderService.Load(_nextSceneName);
            }
        }

        #endregion
    }
}