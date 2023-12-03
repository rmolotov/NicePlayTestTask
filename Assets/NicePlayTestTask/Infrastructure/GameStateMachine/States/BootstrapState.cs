using NicePlayTestTask.Infrastructure.GameStateMachine.States.Interfaces;

namespace NicePlayTestTask.Infrastructure.GameStateMachine.States
{
    public class BootstrapState : IState
    {
        private readonly GameStateMachine _stateMachine;
        // private readonly IStaticDataService _staticDataService;

        public BootstrapState(GameStateMachine gameStateMachine 
            // IStaticDataService staticDataService
            )
        {
            _stateMachine = gameStateMachine;
            // _staticDataService = staticDataService;
        }
        
        public void Enter()
        {
            _stateMachine.Enter<LoadProgressState>();
        }

        public void Exit()
        {
            
        }
    }
}