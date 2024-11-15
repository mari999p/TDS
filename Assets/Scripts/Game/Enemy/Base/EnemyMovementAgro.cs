using TDS.Game.Common;
using UnityEngine;

namespace TDS.Game.Enemy.Base
{
    public sealed class EnemyMovementAgro : EnemyBehaviour
    {
        #region Variables

        [SerializeField] private TriggerObserver _moveObserver;
        [SerializeField] private TriggerObserver _stopChasingObserver;
        [SerializeField] private EnemyIdle _idle;
        [SerializeField] private EnemyMovement _movement;
        [SerializeField] private LayerMask _obstacleMask;

        private bool _isFollowing;

        #endregion

        #region Unity lifecycle

        private void OnEnable()
        {
            _moveObserver.OnStayed += TriggerStayedCallback;

            if (_stopChasingObserver != null)
            {
                _stopChasingObserver.OnExited += TriggerExitedCallback;
            }
            else
            {
                _moveObserver.OnExited += TriggerExitedCallback;
            }
        }

        private void OnDisable()
        {
            _moveObserver.OnStayed -= TriggerStayedCallback;

            if (_stopChasingObserver != null)
            {
                _stopChasingObserver.OnExited -= TriggerExitedCallback;
            }
            else
            {
                _moveObserver.OnExited -= TriggerExitedCallback;
            }
        }

        #endregion

        #region Private methods

        private void TriggerExitedCallback(Collider2D col)
        {
            if (!col.CompareTag(Tag.Player))
            {
                return;
            }

            _isFollowing = false;
            _movement.Deactivate();
            _idle.Activate();
        }

        private void TriggerStayedCallback(Collider2D col)
        {
            if (_isFollowing || !col.CompareTag(Tag.Player))
            {
                return;
            }

            Vector3 direction = col.transform.position - transform.position;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, direction.magnitude, _obstacleMask);
            if (hit.transform != null)
            {
                return;
            }

            _isFollowing = true;
            _idle.Deactivate();
            _movement.Activate();
            _movement.SetTarget(col.transform);
        }

        #endregion
    }
}