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

        [SerializeField] [Range(0, 360)] private float _viewAngle = 90f;
        [SerializeField] [Range(0, 360)] private float _initialDirectionAngle;
        [SerializeField] private float _viewDistance = 10f;
        [SerializeField] private float _noticeDistance = 3f;

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

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.magenta;
            Vector3 initialDirection = Quaternion.Euler(0, 0, _initialDirectionAngle) * transform.right;

            Vector3 leftBoundary = Quaternion.Euler(0, 0, -_viewAngle / 2) * initialDirection;
            Vector3 rightBoundary = Quaternion.Euler(0, 0, _viewAngle / 2) * initialDirection;

            Gizmos.DrawLine(transform.position, transform.position + leftBoundary * _viewDistance);
            Gizmos.DrawLine(transform.position, transform.position + rightBoundary * _viewDistance);
            Gizmos.DrawWireSphere(transform.position, _viewDistance);

            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, _noticeDistance);
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

        private void TriggerStayedCallback(Collider2D col) //3
        {
            if (_isFollowing || !col.CompareTag(Tag.Player))
            {
                return;
            }

            Vector3 directionToPlayer = (col.transform.position - transform.position).normalized;
            float distanceToPlayer = (col.transform.position - transform.position).magnitude;
            Vector3 initialDirection = Quaternion.Euler(0, 0, _initialDirectionAngle) * transform.right;
            if (distanceToPlayer <= _noticeDistance ||
                (Vector3.Angle(initialDirection, directionToPlayer) <= _viewAngle / 2 &&
                 distanceToPlayer <= _viewDistance))
            {
                RaycastHit2D hit =
                    Physics2D.Raycast(transform.position, directionToPlayer, _viewDistance, _obstacleMask);
                if (hit.transform != null && hit.transform != col.transform)
                {
                    return;
                }

                _isFollowing = true;
                _idle.Deactivate();
                _movement.Activate();
                _movement.SetTarget(col.transform);
            }
        }

        #endregion
    }
}