using TDS.Infrastructure.Locator;

namespace TDS.Infrastructure.State
{
    public class StateMachine : IService
    {
        #region Variables

        private State _currentState;

        #endregion

        #region Public methods

        public void Enter<T>() where T : AppState, new()
        {
            _currentState?.Exit();
            T state = new();
            _currentState = state;
            _currentState.Setup(this);
            state.Enter();
        }

        #endregion
    }
}