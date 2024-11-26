using TDS.Game.Player;
using TMPro;
using UnityEngine;

namespace TDS.Game.UI
{
    public class AmmoDisplay : MonoBehaviour
    {
        #region Variables

        [SerializeField] private TMP_Text _ammoText;
        [SerializeField] private PlayerAmmo _playerAmmo;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            if (_playerAmmo == null)
            {
                return;
            }

            Init();
        }

        private void OnDestroy()
        {
            Clear();
        }

        #endregion

        #region Public methods

        public void Construct(PlayerAmmo playerAmmo)
        {
            Clear();
            _playerAmmo = playerAmmo;
            Init();
        }

        #endregion

        #region Private methods

        private void AmmoChangedCallback(int currentAmmo)
        {
            UpdateUI();
        }

        private void Clear()
        {
            if (_playerAmmo != null)
            {
                _playerAmmo.OnAmmoChanged -= AmmoChangedCallback;
            }
        }

        private void Init()
        {
            _playerAmmo.OnAmmoChanged += AmmoChangedCallback;
            UpdateUI();
        }

        private void UpdateUI()
        {
            _ammoText.text = $"{_playerAmmo.CurrentAmmo} / {_playerAmmo.MaxAmmo}";
        }

        #endregion
    }
}