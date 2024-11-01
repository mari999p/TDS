using System.Collections.Generic;
using UnityEngine;

namespace TDS.Game.Enemy.Base
{
    public class PatrolEnemyMovement : EnemyMovement
    {
        #region Variables

        [SerializeField] private List<Transform> _patrolPoints;
        [SerializeField] private int _currentPointIndex;
        [SerializeField] private float _patrolSpeed = 2f;

        [SerializeField] private bool _isPatrolling = true;

        #endregion

        #region Unity lifecycle

        private void Update()
        {
            if (_isPatrolling)
            {
                Patrol();
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;

            if (_patrolPoints is { Count: > 0 })
            {
                foreach (Transform point in _patrolPoints)
                {
                    Gizmos.DrawSphere(point.position, 0.2f);
                }
            }
        }

        #endregion

        #region Public methods

        public void ReturnToPatrolling()
        {
            _isPatrolling = true;
        }

        public override void SetTarget(Transform target)
        {
            _isPatrolling = false;
        }

        #endregion

        #region Private methods

        private void Patrol()
        {
            if (_patrolPoints == null || _patrolPoints.Count == 0)
            {
                return;
            }

            Transform targetPoint = _patrolPoints[_currentPointIndex];
            Vector2 direction = targetPoint.position - transform.position;
            if (direction.magnitude < 0.1f)
            {
                _currentPointIndex = (_currentPointIndex + 1) % _patrolPoints.Count;
                return;
            }

            Vector2 velocity = direction.normalized * _patrolSpeed;
            transform.position += (Vector3)velocity * Time.deltaTime;
        }

        #endregion
    }
}