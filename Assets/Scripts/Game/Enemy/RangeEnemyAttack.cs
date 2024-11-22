using Lean.Pool;
using TDS.Game.Enemy.Base;
using TDS.Game.Player;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public class RangeEnemyAttack : EnemyAttack
    {
        #region Variables

        [Header(nameof(RangeEnemyAttack))]
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private Transform _spawnPointTransform;

        #endregion

        #region Unity lifecycle

        protected override void Update()
        {
            base.Update();

            if (Target == null)
            {
                return;
            }

            Rotate();
        }

        #endregion

        #region Protected methods

        protected override void OnPerformAttack()
        {
            base.OnPerformAttack();

            LeanPool.Spawn(_bulletPrefab, _spawnPointTransform.position, _spawnPointTransform.rotation);
        }

        #endregion

        #region Private methods

        private void Rotate()
        {
            transform.up = Target.position - transform.position;
        }

        #endregion
    }
}