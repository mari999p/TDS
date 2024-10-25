using TDS.Infrastructure.Locator;
using TDS.Infrastructure.State;
using UnityEngine;

namespace TDS.Infrastructure
{
    public class Bootstrapper : MonoBehaviour
    {
        #region Unity lifecycle

        private void Awake()
        {
            StateMachine sm = new();
            ServicesLocator.Instance.Register(sm);
            sm.Enter<BootstrapState>();
        }

        #endregion
    }
}