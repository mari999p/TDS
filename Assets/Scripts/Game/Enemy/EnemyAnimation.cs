using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyAnimation : MonoBehaviour
    {
        #region Variables

        private static readonly int Death = Animator.StringToHash("death");
        private static readonly int Fire = Animator.StringToHash("fire");

        [SerializeField] private Animator _animator;

        #endregion

        #region Public methods

        public void TriggerAttack()
        {
            _animator.SetTrigger(Fire);
        }

        public void TriggerDeath()
        {
            _animator.SetTrigger(Death);
        }

        #endregion
    }
}