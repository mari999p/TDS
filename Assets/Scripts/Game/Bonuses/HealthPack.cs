using TDS.Game.UI;
using UnityEngine;

namespace TDS.Game.Bonuses
{
    public class HealthPack : MonoBehaviour
    {
        #region Variables

        [Header("HP Settings")]
        [SerializeField] private int _healthAmount = 20;

        #endregion

        #region Unity lifecycle

        private void OnTriggerEnter2D(Collider2D other)
        {
            PlayerHp playerHp = other.GetComponent<PlayerHp>();
            if (playerHp != null)
            {
                Debug.Log("Аптечка подобрана");
                playerHp.Heal(_healthAmount);
                Destroy(gameObject);
            }
        }

        #endregion
    }
}