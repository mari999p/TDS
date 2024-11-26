using System;
using UnityEngine;

namespace TDS.Game.Player
{
    public class PlayerAmmo : MonoBehaviour
    {
        #region Variables

        [SerializeField] private int _maxAmmo = 100;
        [SerializeField] private int _currentAmmo;

        #endregion

        #region Events

        public event Action<int> OnAmmoChanged;

        #endregion

        #region Properties

        public int CurrentAmmo => _currentAmmo;
        public int MaxAmmo => _maxAmmo;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            _currentAmmo = _maxAmmo;
            OnAmmoChanged?.Invoke(_currentAmmo);
        }

        #endregion

        #region Public methods

        public void AddAmmo(int amount)
        {
            _currentAmmo = Mathf.Clamp(_currentAmmo + amount, 0, _maxAmmo);
            OnAmmoChanged?.Invoke(_currentAmmo);
        }

        public bool TryToShoot()
        {
            if (_currentAmmo > 0)
            {
                _currentAmmo--;
                OnAmmoChanged?.Invoke(_currentAmmo);
                return true;
            }

            return false;
        }

        #endregion
    }
}