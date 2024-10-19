using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyAnimation : MonoBehaviour
    {
        private static readonly int Fire = Animator.StringToHash("fire");
        private static readonly int Death = Animator.StringToHash("death");

        [SerializeField] private Animator _animator;

        public void TriggerAttack()
        {
                _animator.SetTrigger(Fire);
          
        }

        public void TriggerDeath()
        {
            _animator.SetTrigger(Death);
        }
        
    }
}