using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyAnimation : MonoBehaviour
    {
        private static readonly int Fire = Animator.StringToHash("fire");

        [SerializeField] private Animator _animator;

        public void TriggerAttack()
        {
            if (_animator != null)
            {
                _animator.SetTrigger(Fire);
            }
            else
            {
                Debug.LogError("Animator not assigned on " + gameObject.name);
            }
        }
        
    }
}