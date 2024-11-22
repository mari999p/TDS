using Lean.Pool;
using UnityEngine;

namespace TDS.Game.Player

{
    public class PlayerAttack : MonoBehaviour
    {
        #region Variables

        [Header("Components")]
        [SerializeField] private PlayerAnimation _animation;

        [Header("Settings")]
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private Transform _spawnPointTransform;
        [SerializeField] private PlayerAmmo _playerAmmo;

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
                _animation.TriggerAttack();
                LeanPool.Spawn(_bulletPrefab, _spawnPointTransform.position, _spawnPointTransform.rotation);
                _playerAmmo.AddAmmo(-1); 
            }
        }

        #endregion
    }
}