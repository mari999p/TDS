using UnityEngine;

namespace TDS.Game

{
    public class PlayerAttack : MonoBehaviour
    {
        #region Variables

        [Header("Components")]
        [SerializeField] private PlayerAnimation _animation;

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

        #region Private methods

        private void Fire()
        {
            _animation.TriggerAttack();
            Instantiate(_bulletPrefab, _spawnPointTransform.position, _spawnPointTransform.rotation);
        }

        #endregion
    }
}