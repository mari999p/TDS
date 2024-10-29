using TDS.Game.Enemy.Base;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public class DirectEnemyMovement : EnemyMovement
    {
        #region Variables

        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private float _speed = 3f;
        [SerializeField] private float _detectionDistance = 5f;

        private bool _isChasing;

        private Transform _target;

        #endregion

        #region Unity lifecycle

        private void Update()
        {
            if (_target == null)
            {
                return;
            }

            if (_isChasing)
            {
                CheckDistance();
                Rotate();
                Move();
            }
        }

        private void OnDisable()
        {
            _rb.velocity = Vector2.zero;
            _isChasing = false;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _detectionDistance);
        }

        #endregion

        #region Public methods

        public override void SetTarget(Transform target)
        {
            _target = target;
            _isChasing = true;
        }

        #endregion

        #region Private methods

        private void CheckDistance()
        {
            if (Vector2.Distance(transform.position, _target.position) > _detectionDistance)
            {
                _isChasing = false;
            }
        }

        private void Move()
        {
            Vector2 velocity = transform.up * _speed;
            _rb.velocity = velocity;
            // _animation.SetMovement(direction.magnitude);
        }

        private void Rotate()
        {
            transform.up = _target.position - transform.position;
        }

        #endregion
    }
}