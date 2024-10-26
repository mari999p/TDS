using TDS.Game.Common;
using UnityEngine;

namespace TDS.Game.Enemy.Base
{
    public class EnemyMovementAgro : EnemyBehaviour
    {
        #region Variables

        [SerializeField] private TriggerObserver _triggerObserver;
        [SerializeField] private EnemyIdle _idle;
        [SerializeField] private EnemyMovement _movement;

        #endregion

        #region Unity lifecycle

        private void OnEnable()
        {
            _triggerObserver.OnEntered += TriggerEnteredCallback;
        }

        private void OnDisable()
        {
            _triggerObserver.OnEntered -= TriggerEnteredCallback;
        }

        #endregion

        #region Private methods

        private void TriggerEnteredCallback(Collider2D col)
        {
            if (!col.CompareTag(Tag.Player))
            {
                return;
            }

            _idle.Deactivate();
            _movement.Activate();
            _movement.SetTarget(col.transform);
        }

        #endregion
    }
}