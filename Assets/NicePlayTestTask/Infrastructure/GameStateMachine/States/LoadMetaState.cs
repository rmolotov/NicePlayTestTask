using NicePlayTestTask.Infrastructure.GameStateMachine.States.Interfaces;

namespace NicePlayTestTask.Infrastructure.GameStateMachine.States
{
    public class LoadMetaState : IState
    {
        private readonly GameStateMachine _stateMachine;

        public LoadMetaState(GameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
        
        public void Enter()
        {
            _stateMachine.Enter<LoadLevelState, string>("game");
        }

        public void Exit()
        {
            
        }
    }
}