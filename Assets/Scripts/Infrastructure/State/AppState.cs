namespace TDS.Infrastructure.State
{
    public abstract class AppState: State
    {
        public abstract void Enter();
    }
}