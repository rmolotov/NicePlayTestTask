namespace NicePlayTestTask.Infrastructure.GameStateMachine.States.Interfaces
{
    public interface IState : IExitableState
    {
        void Enter();
    }
}