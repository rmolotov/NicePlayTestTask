namespace NicePlayTestTask.Infrastructure.GameStateMachine.States.Interfaces
{
    public interface IPayloadedState<TPayload> : IExitableState
    {
        void Enter(TPayload payload);
    }
}