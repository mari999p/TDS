using Pathfinding;
using UnityEngine;

namespace TDS.Game.Enemy.Base
{
    public class AIPathMovement : EnemyMovement
    {
        #region Variables

        [SerializeField] private AIPath _aiPath;
        [SerializeField] private Transform _currentTarget;
        [SerializeField] private Collider2D _collider;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            _aiPath = GetComponent<AIPath>();
        }

        private void Update()
        {
            if (!_collider.enabled)
            {
                return;
            }

            _aiPath.destination = _currentTarget.position;
        }

        private void OnEnable()
        {
            _aiPath.canMove = true;
        }

        private void OnDisable()
        {
            StopMovement();
        }

        #endregion

        #region Public methods

        public override void SetTarget(Transform target)
        {
            _currentTarget = target;
            _aiPath.canMove = true;
            _aiPath.SearchPath();
        }

        #endregion

        #region Private methods

        private void StopMovement()
        {
            _aiPath.canMove = false;
            _currentTarget = null;
        }

        #endregion
    }
}