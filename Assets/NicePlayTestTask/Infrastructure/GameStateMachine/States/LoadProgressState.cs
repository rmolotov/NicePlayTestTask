using NicePlayTestTask.Infrastructure.GameStateMachine.States.Interfaces;

namespace NicePlayTestTask.Infrastructure.GameStateMachine.States
{
    public class LoadProgressState : IState
    {
        private readonly GameStateMachine _stateMachine;

        public LoadProgressState(GameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
        
        public void Enter()
        {
            _stateMachine.Enter<LoadMetaState>();
        }

        public void Exit()
        {
            
        }
    }
}