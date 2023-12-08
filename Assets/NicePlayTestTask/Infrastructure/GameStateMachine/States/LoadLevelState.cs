using System.Threading.Tasks;
using UnityEngine;
using NicePlayTestTask.Infrastructure.Factorises.Interfaces;
using NicePlayTestTask.Infrastructure.GameStateMachine.States.Interfaces;
using NicePlayTestTask.Infrastructure.SceneManagement;
using NicePlayTestTask.Services.PersistentData;
using NicePlayTestTask.Services.LevelProgress;

namespace NicePlayTestTask.Infrastructure.GameStateMachine.States
{
    public class LoadLevelState : IPayloadedState<bool>
    {
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly IUIFactory _uiFactory;
        private readonly IPersistentDataService _persistentDataService;
        private readonly ILevelProgressService _levelProgressService;

        private Canvas _uiRoot;
        private bool _needProgress = false;

        public LoadLevelState(GameStateMachine gameStateMachine,
            SceneLoader sceneLoader,
            IUIFactory uiFactory,
            ILevelProgressService levelProgressService, IPersistentDataService persistentDataService)
        {
            _stateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _uiFactory = uiFactory;
            _persistentDataService = persistentDataService;
            _levelProgressService = levelProgressService;
        }
        
        public async void Enter(bool payload)
        {
            _needProgress = payload;
            var sceneInstance = await _sceneLoader.Load(SceneName.Core, OnLoaded);
        }

        public void Exit()
        {
            
        }
        
        private async void OnLoaded(SceneName sceneName)
        {
            await Task.WhenAll(
                InitUIRoot(),
                InitGameWold(),
                InitUI()
            );
            
            _stateMachine.Enter<GameLoopState>();
        }
        
        private async Task InitUIRoot()
        {
            _uiRoot = await _uiFactory.GetOrCreateUIRoot();
            _uiRoot.enabled = false;
        }

        private async Task InitGameWold()
        {

        }

        private async Task InitUI()
        {
            var hud = await _uiFactory.GetOrCreateHud();
            hud.Reset();
            
            _levelProgressService.LevelProgressWatcher.ScoreChanged += hud.UpdateScore;
            _levelProgressService.LevelProgressWatcher.BestDishChanged += hud.UpdateBestDish;
            _levelProgressService.LevelProgressWatcher.LastDishChanged += hud.UpdateLastDish;

            if (_needProgress)
                LoadProgressFromSave();
            
            _uiRoot.enabled = true;
        }

        private void LoadProgressFromSave()
        {
            _levelProgressService.LevelProgressWatcher.CurrentScore = _persistentDataService.Progress.Score;
            _levelProgressService.LevelProgressWatcher.BestDishData = _persistentDataService.Progress.BestDish;
            _levelProgressService.LevelProgressWatcher.LastDishData = _persistentDataService.Progress.LastDish;
        }
    }
}