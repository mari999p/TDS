using TDS.Game.UI;
using UnityEngine;

namespace TDS.UI
{
    public class GameScreen : MonoBehaviour
    {
        #region Variables

        [SerializeField] private HpBar _playerHpBar;

        #endregion

        #region Properties

        public HpBar PlayerHpBar => _playerHpBar;

        #endregion
    }
}