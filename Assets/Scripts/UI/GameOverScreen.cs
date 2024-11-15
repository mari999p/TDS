using TDS.Game.Player;
using TDS.Infrastructure.Locator;
using TDS.Service.SceneLoading;
using UnityEngine;
using UnityEngine.UI;

namespace TDS.UI
{
    public class GameOverScreen : MonoBehaviour
    {
        #region Variables

        [SerializeField] private PlayerDeath _playerDeath;
        [SerializeField] private Button _retryButton;

        [SerializeField] private string _currentSceneName;

        #endregion

        #region Unity lifecycle

        private void OnEnable()
        {
            _playerDeath.OnDeathOccurred += ShowRetryButton;
            _retryButton.gameObject.SetActive(false);
            _retryButton.onClick.AddListener(RetryLevel);
        }

        private void OnDisable()
        {
            _playerDeath.OnDeathOccurred -= ShowRetryButton;
            _retryButton.onClick.RemoveListener(RetryLevel);
        }

        #endregion

        #region Private methods

        private void RetryLevel()
        {
            ServicesLocator.Instance.Get<SceneLoaderService>().RetrySceneWithDelay(_currentSceneName);
        }

        private void ShowRetryButton()
        {
            _retryButton.gameObject.SetActive(true);
        }

        #endregion
    }
}