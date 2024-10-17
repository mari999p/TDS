using UnityEngine;

namespace TDS.Game
{
    public class PlayerAnimation : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Animator _animator;
        private static readonly int Movement = Animator.StringToHash("movement");
        private static readonly int Fire = Animator.StringToHash("fire");

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

        #endregion
    }
}