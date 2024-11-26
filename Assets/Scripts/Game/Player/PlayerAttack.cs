using Lean.Pool;
using UnityEngine;

namespace TDS.Game.Player

{
    public class PlayerAttack : MonoBehaviour
    {
        #region Variables

        [Header("Components")]
        [SerializeField] private PlayerAnimation _animation;
        [SerializeField] private PlayerAmmo _playerAmmo;

        [Header("Settings")]
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private Transform _spawnPointTransform;

        #endregion

        #region Unity lifecycle

        private void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Fire();
            }
        }

        #endregion

        #region Public methods

        public void Deactivate()
        {
            enabled = false;
        }

        #endregion

        #region Private methods

        private void Fire()
        {
            if (_playerAmmo.TryToShoot())
            {
                LeanPool.Spawn(_bulletPrefab, _spawnPointTransform.position, _spawnPointTransform.rotation);
            }
        }

        #endregion
    }
}