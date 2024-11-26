using System;
using Pathfinding;
using TDS.Game.Common;
using TDS.Game.UI;
using TDS.Service.PickUp;
using UnityEngine;

namespace TDS.Game.Enemy.Base
{
    public class EnemyDeath : EnemyBehaviour
    {
        #region Variables

        [SerializeField] private UnitHp _hp;
        [SerializeField] private Collider2D _collider;
        [SerializeField] private EnemyMovement _movement;
        [SerializeField] private EnemyAttack _attack;
        [SerializeField] private EnemyIdle _idle;
        [SerializeField] private EnemyMovementAgro _movementAgro;
        [SerializeField] private EnemyAttackAgro _attackAgro;
        [SerializeField] private EnemyAnimation _animation;
        [SerializeField] private PickUpService _pickUpService;
        [SerializeField] private HpBar _hpBar;
     
        

        #endregion

        #region Events

        public event Action OnHappened;

        #endregion

        #region Properties

        public bool IsDead { get; private set; }

        #endregion

        #region Unity lifecycle
        

        private void OnEnable()
        {
            _hp.OnChanged += HpChangedCallback;
        }

        private void OnDisable()
        {
            _hp.OnChanged -= HpChangedCallback;
        }

        #endregion

        #region Private methods

        private void Die()
        {
            IsDead = true;

            _collider.enabled = false;
            _movement.Deactivate();
            _attack.Deactivate();
            _idle.Deactivate();
            _attackAgro.Deactivate();
            _movementAgro.Deactivate();
            _animation.PlayDeath();
            OnHappened?.Invoke();
            _pickUpService.TrySpawnPickup(transform.position);
            OnEnemyDeath();
            
        }

        private void HpChangedCallback(int hp)
        {
            if (hp > 0 || IsDead)
            {
                return;
            }

            Die();
        }

        private void OnEnemyDeath()
        {
            _hpBar.gameObject.SetActive(false);
        }

        #endregion
    }
}