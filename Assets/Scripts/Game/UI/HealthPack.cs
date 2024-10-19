using UnityEngine;

namespace TDS.Game.UI
{
    public class HealthPack :MonoBehaviour
    {
        [SerializeField] private int _healthAmount = 20;

        private void OnTriggerEnter2D(Collider2D other)
        {
            PlayerHp playerHp = other.GetComponent<PlayerHp>();
            if (playerHp != null)
            {
                playerHp.Heal(_healthAmount);
                Destroy(gameObject);
            }
        }
    }
}