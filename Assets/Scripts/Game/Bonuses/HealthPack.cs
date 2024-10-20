using TDS.Game.Player;
using TDS.Infrastructure.Locator;
using UnityEngine;

namespace TDS.Game.Bonuses
{
    public class HealthPack : BonusPackage
    {
        #region Variables

        [Header(nameof(HealthPack))]
        [SerializeField] private int _healthAmount = 20;

        #endregion

        #region Protected methods

        protected override void PerformActions()
        {
            base.PerformActions();
            Debug.Log("Аптечка подобрана");
            ServicesLocator.Instance.Get<PlayerHp>().Heal(_healthAmount);
        }

        #endregion
    }
}