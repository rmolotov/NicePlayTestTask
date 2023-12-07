using System.Collections.Generic;
using NicePlayTestTask.Data;
using NicePlayTestTask.Infrastructure.GameStateMachine.States.Interfaces;
using NicePlayTestTask.Services.PersistentData;
using NicePlayTestTask.Services.SaveLoad;

namespace NicePlayTestTask.Infrastructure.GameStateMachine.States
{
    public class LoadProgressState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly IPersistentDataService _progressService;
        private readonly ISaveLoadService _saveLoadProgressService;

        public LoadProgressState(
            GameStateMachine stateMachine, 
            IPersistentDataService progressService, 
            ISaveLoadService saveLoadService)
        {
            _stateMachine = stateMachine;
            _progressService = progressService;
            _saveLoadProgressService = saveLoadService;
        }
        
        public void Enter()
        {
            LoadProgressOrInitNew();

            _stateMachine.Enter<LoadMetaState>();
        }

        public void Exit()
        {
            
        }
        
        private async void LoadProgressOrInitNew()
        {
            _progressService.Progress = 
                await _saveLoadProgressService.LoadProgress() 
                ?? NewProgress();
        }
        
        private PlayerProgressData NewProgress() =>
            new()
            {
                Score = 0,
                BestDish = null,
                LastDish = null,
                UnlockedRecipes = new HashSet<string>()
            };
    }
}