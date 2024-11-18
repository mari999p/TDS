using TDS.Game.Enemy.Base;
using UnityEngine;

namespace TDS.Game.UI
{
    public class HpBarFollower : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Camera _camera;
        [SerializeField] private Transform _target;
        [SerializeField] private Vector3 _offset;
        [SerializeField] private HpBar _hpBar;
        [SerializeField] private EnemyDeath _enemyDeath;

        #endregion

        #region Unity lifecycle

        private void Update()
        {
            transform.LookAt(transform.position + _camera.transform.rotation * Vector3.forward,
                _camera.transform.rotation * Vector3.up);
            transform.position = _target.position + _offset;
        }

        private void OnEnable()
        {
            _enemyDeath.OnHappened += OnEnemyDeath;
        }

        private void OnDisable()
        {
            _enemyDeath.OnHappened -= OnEnemyDeath;
        }

        #endregion

        #region Private methods

        private void OnEnemyDeath()
        {
            _hpBar.gameObject.SetActive(false);
        }

        #endregion
    }
}
// 1.