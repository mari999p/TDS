using System.Collections;
using TDS.Game.Player;
using UnityEngine;

namespace TDS.Game.UI
{
    public class PlayerHp: MonoBehaviour
    {
        [Header("Health Settings")]
        [SerializeField] private int _maxHealth = 100;
        [SerializeField] private int _currentHealth;
        [SerializeField] private PlayerAnimation _animation;
        [SerializeField] private float _deathDelay = 5f;
        
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private PlayerAttack _playerAttack;
        
        
         private void Start()
        {
            _currentHealth = _maxHealth;
          
            
        }

        public void TakeDamage(int damage)
        {
            _currentHealth -= damage;
            if (_currentHealth <= 0)
            {
                StartCoroutine(Die());
            }
        }

        public void Heal(int amount)
        {
            _currentHealth = Mathf.Min(_currentHealth + amount, _maxHealth);
        }

        private IEnumerator Die()
        {
            _playerMovement.enabled = false;
            _playerAttack.enabled = false;
            _animation.TriggerDeath();
            Debug.Log("ПЕРС УМЕР");
            yield return new WaitForSeconds(_deathDelay);
        }
    }
}