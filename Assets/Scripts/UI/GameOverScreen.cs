using TDS.Game.Player;
using TDS.Infrastructure.Locator;
using TDS.Service.Restart;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TDS.UI
{
    public class GameOverScreen : MonoBehaviour
    {
        #region Variables

        [SerializeField] private PlayerDeath _playerDeath;
        [SerializeField] private GameObject _gameOverPanel;
        [SerializeField] private Button _retryButton;

        #endregion

        #region Unity lifecycle

        private void OnEnable()
        {
            _playerDeath.OnDeathOccurred += ShowRetryButton;
            _gameOverPanel.SetActive(false);
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
            RestartService restartService = ServicesLocator.Instance.Get<RestartService>();
            restartService.Restart(SceneManager.GetActiveScene().name);
        }

        private void ShowRetryButton()
        {
            _gameOverPanel.SetActive(true);
        }

        #endregion
    }
}