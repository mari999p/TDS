using TDS.Game.Enemy.Base;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public class DirectEnemyMovement : EnemyMovement
    {
        #region Variables

        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private float _speed = 3f;

        private Transform _target;

        #endregion

        #region Unity lifecycle

        private void Update()
        {
            if (_target == null)
            {
                return;
            }

            Rotate();
            Move();
        }

        private void OnDisable()
        {
            ResetVelocity();
        }

        #endregion

        #region Public methods

        public override void SetTarget(Transform target)
        {
            _target = target;

            if (target == null)
            {
                ResetVelocity();
            }
        }

        #endregion

        #region Private methods

        private void Move()
        {
            Vector2 velocity = transform.up * _speed;
            _rb.velocity = velocity;
            Animation.SetSpeed(_speed);
        }

        private void ResetVelocity()
        {
            _rb.velocity = Vector2.zero;
            Animation.SetSpeed(0);
        }

        private void Rotate()
        {
            transform.up = _target.position - transform.position;
        }

        #endregion
    }
}