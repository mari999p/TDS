using TDS.Game.Player;
using UnityEngine;

namespace TDS.Game.PickUps
{
    public class AmmoPack : PickUp
    {
        #region Variables

        [Header(nameof(AmmoPack))]
        [SerializeField] private int _ammoAmount = 20;

        #endregion

        #region Protected methods

        protected override void PerformActions(Collider2D other)
        {
            base.PerformActions(other);
            if (other.CompareTag(Tag.Player))
            {
                Debug.Log("Ящик с патронами подобран");
                PlayerAmmo playerAmmo = other.GetComponent<PlayerAmmo>();
                if (playerAmmo != null)
                {
                    playerAmmo.AddAmmo(_ammoAmount);
                }
            }
        }

        #endregion
    }
}