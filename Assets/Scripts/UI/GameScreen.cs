using TDS.Game.UI;
using UnityEngine;

namespace TDS.UI
{
    public class GameScreen : MonoBehaviour
    {
        #region Variables

        [SerializeField] private HpBar _playerHpBar;
        [SerializeField] private AmmoDisplay _ammoDisplay;
        [SerializeField] private BossHpBar _bossHpBar;
        #endregion

        #region Properties

        public AmmoDisplay AmmoDisplay => _ammoDisplay;

        public HpBar PlayerHpBar => _playerHpBar;
        public BossHpBar BossHpBar => _bossHpBar; 

        #endregion
    }
}