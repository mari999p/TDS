using TDS.Infrastructure.Locator;
using TDS.Service.SceneLoading;
using UnityEngine;

namespace TDS.Infrastructure.State
{
    public class BootstrapState : AppState
    {
        #region Public methods

        public override void Enter()
        {
            Debug.Log("BootstrapState Enter");
            ServicesLocator.Instance.Register(new SceneLoaderService());
            StateMachine.Enter<LoadGameState>();
        }

        public override void Exit() { }

        #endregion
    }
}