using NicePlayTestTask.Infrastructure.GameStateMachine.States.Interfaces;
using NicePlayTestTask.Services.LevelProgress;

namespace NicePlayTestTask.Infrastructure.GameStateMachine.States
{
    public class GameLoopState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly ILevelProgressService _levelProgressService;

        public GameLoopState(GameStateMachine stateMachine, ILevelProgressService levelProgressService)
        {
            _stateMachine = stateMachine;
            _levelProgressService = levelProgressService;
        }
        
        public void Enter()
        {
            _levelProgressService.LevelProgressWatcher.RunLevel();
        }

        public void Exit()
        {
            
        }
    }
}