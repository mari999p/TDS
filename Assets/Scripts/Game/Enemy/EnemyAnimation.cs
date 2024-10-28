using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyAnimation : MonoBehaviour
    {
        #region Variables

        private static readonly int Attack = Animator.StringToHash("attack");
        [SerializeField] private Animator _animator;

        #endregion

        #region Public methods

        public void TriggerAttack()
        {
            _animator.SetTrigger(Attack);
        }

        #endregion
    }
}