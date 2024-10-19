using System.Collections;
using TDS.Game.Enemy;
using UnityEngine;

namespace TDS.Game.UI
{
    public class EnemyHp : MonoBehaviour
    {
        [Header("Health Settings")]
        [SerializeField] private int _maxHealth = 100;
        [SerializeField] private int _currentHealth;
        [SerializeField] private EnemyAnimation _animation;
        [SerializeField] private EnemyAttack _enemyAttack;
     
        private void Start()
        {
            _currentHealth = _maxHealth;
        }

        public void TakeDamage(int damage)
        {
           
            _currentHealth -= damage;
            if (_currentHealth <= 0)
            {
               Die();
            }
        }

        private void Die()
        {
           
            _enemyAttack.enabled = false;
            _enemyAttack.StopAttacking();
            _animation.TriggerDeath();
        }
    

}
}