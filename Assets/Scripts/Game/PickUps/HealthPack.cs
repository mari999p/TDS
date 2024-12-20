using TDS.Game.Player;
using UnityEngine;

namespace TDS.Game.PickUps
{
    public class HealthPack : PickUp
    {
        #region Variables

        [Header(nameof(HealthPack))]
        [SerializeField] private int _healthAmount = 20;

        #endregion

        #region Protected methods

        protected override void PerformActions(Collider2D other)
        {
            base.PerformActions(other);
            if (other.CompareTag(Tag.Player))
            {
                Debug.Log("Аптечка подобрана");
                other.gameObject.GetComponent<PlayerDeath>().Heal(_healthAmount);
            }
        }

        #endregion
    }
}