using UnityEngine;

namespace TDS.Game.Player
{
    public class PlayerAnimation : MonoBehaviour
    {
        #region Variables

        private static readonly int Death = Animator.StringToHash("death");
        private static readonly int Fire = Animator.StringToHash("fire");
        private static readonly int Movement = Animator.StringToHash("movement");

        [SerializeField] private Animator _animator;

        #endregion

        #region Public methods

        public void SetMovement(float sped)
        {
            _animator.SetFloat(Movement, sped);
        }

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