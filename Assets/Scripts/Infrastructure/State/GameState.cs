using TDS.Game.Common;
using TDS.Game.Player;
using TDS.Service.LevelCompletion;
using TDS.Service.Mission;
using TDS.UI;
using TDS.Utils.Log;
using UnityEngine;

namespace TDS.Infrastructure.State
{
    public class GameState : AppState
    {
        #region Public methods

        public override void Enter()
        {
            this.Log();
            ServicesLocator.Get<LevelCompletionService>().Initialize();
            ServicesLocator.Get<MissionService>().Initialize();
            ServicesLocator.Get<MissionService>().Begin();

            GameScreen gameScreen = Object.FindObjectOfType<GameScreen>();
            PlayerMovement playerMovement = Object.FindObjectOfType<PlayerMovement>();
            UnitHp playerHp = playerMovement.GetComponent<UnitHp>();
            gameScreen.PlayerHpBar.Construct(playerHp);
            PlayerAmmo playerAmmo = playerMovement.GetComponent<PlayerAmmo>();
            gameScreen.AmmoDisplay.Construct(playerAmmo);
            BossHp bossHp = Object.FindObjectOfType<BossHp>();
            if (bossHp != null)
            {
                gameScreen.BossHpBar.Construct(bossHp);
            }
        }

        public override void Exit()
        {
            ServicesLocator.Get<MissionService>().Dispose();
            ServicesLocator.Get<LevelCompletionService>().Dispose();
        }

        #endregion
    }
}