using NicePlayTestTask.Infrastructure.Factorises.Interfaces;
using NicePlayTestTask.Infrastructure.GameStateMachine.States.Interfaces;
using NicePlayTestTask.Services.LevelProgress;

namespace NicePlayTestTask.Infrastructure.GameStateMachine.States
{
    public class GameLoopState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly IUIFactory _uiFactory;
        private readonly ILevelProgressService _levelProgressService;

        public GameLoopState(
            GameStateMachine stateMachine, 
            IUIFactory uiFactory, 
            ILevelProgressService levelProgressService)
        {
            _stateMachine = stateMachine;
            _uiFactory = uiFactory;
            _levelProgressService = levelProgressService;
        }
        
        public async void Enter()
        {
            var hud = await _uiFactory.GetOrCreateHud();
            hud.gameObject.SetActive(true);
            
            _levelProgressService.LevelProgressWatcher.RunLevel();
        }

        public async void Exit()
        {
            var hud = await _uiFactory.GetOrCreateHud();
            hud.gameObject.SetActive(false);
        }
    }
}