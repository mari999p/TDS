using TDS.Infrastructure.Locator;

namespace TDS.Infrastructure.State
{
    public abstract class State
    {
        #region Properties

        protected ServicesLocator ServicesLocator => ServicesLocator.Instance;
        protected StateMachine StateMachine { get; private set; }

        #endregion

        #region Public methods

        public abstract void Exit();

        public void Setup(StateMachine stateMachine)
        {
            StateMachine = stateMachine;
        }

        #endregion
    }
}