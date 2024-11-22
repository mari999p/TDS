using UnityEngine;

namespace TDS.Game.Player
{
    public class PlayerAmmo : MonoBehaviour
    {
        #region Variables

        [SerializeField] private int _maxAmmo = 100;
        [SerializeField]private int _currentAmmo;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            _currentAmmo = _maxAmmo;
        }

        #endregion

        #region Public methods

        public void AddAmmo(int amount)
        {
            _currentAmmo = Mathf.Clamp(_currentAmmo + amount, 0, _maxAmmo);
        }

        public bool TryToShoot()
        {
            if (_currentAmmo > 0)
            {
                return true;
            }

            return false;
        }

        #endregion
    }
}