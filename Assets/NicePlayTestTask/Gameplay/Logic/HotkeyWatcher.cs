using UnityEngine;
using Zenject;
using NicePlayTestTask.Infrastructure.Factorises.Interfaces;
using NicePlayTestTask.Infrastructure.GameStateMachine;
using NicePlayTestTask.Infrastructure.GameStateMachine.States;
using NicePlayTestTask.Meta.CombinationsList;
using NicePlayTestTask.Services.Input;
using NicePlayTestTask.Services.Logging;
using NicePlayTestTask.Services.PersistentData;
using NicePlayTestTask.Services.LevelProgress;
using NicePlayTestTask.Services.SaveLoad;
using NicePlayTestTask.Services.StaticData;

namespace NicePlayTestTask.Gameplay.Logic
{
    public class HotkeyWatcher : MonoBehaviour
    {
        private GameStateMachine _stateMachine;
        private IUIFactory _uiFactory;
        private IInputService _inputService;
        private ILoggingService _loggingService;
        private IStaticDataService _staticDataService;
        private IPersistentDataService _persistentDataService;
        private ILevelProgressService _levelProgressService;
        private ISaveLoadService _saveLoadService;

        private CombinationsWindow _combinationsWindow;

        [Inject]
        private void Construct(
            GameStateMachine stateMachine,
            IUIFactory uiFactory,
            ILoggingService loggingService,
            IInputService inputService,
            IStaticDataService staticDataService,
            IPersistentDataService persistentDataService,
            ILevelProgressService levelProgressService,
            ISaveLoadService saveLoadService)
        {
            _stateMachine = stateMachine;
            _uiFactory = uiFactory;
            _loggingService = loggingService;
            _inputService = inputService;
            _persistentDataService = persistentDataService;
            _staticDataService = staticDataService;
            _levelProgressService = levelProgressService;
            _saveLoadService = saveLoadService;
        }

        private async void Start()
        {
            _combinationsWindow = await _uiFactory.GetOrCreateCombinationsWindow();
            
            _inputService.ReloadScene += () =>
            {
                _levelProgressService.LevelProgressWatcher.RestartLevel();
            };
            
            _inputService.SaveProgress += () =>
            {
                if (_levelProgressService.LevelProgressWatcher.LastDishData == null)
                {
                    _loggingService.LogWarning("save aborted, there's no last dish data!", this);
                }
                else
                {
                    _persistentDataService.Progress.Score    = _levelProgressService.LevelProgressWatcher.CurrentScore;
                    _persistentDataService.Progress.BestDish = _levelProgressService.LevelProgressWatcher.BestDishData;
                    _persistentDataService.Progress.LastDish = _levelProgressService.LevelProgressWatcher.LastDishData;

                    _saveLoadService.SaveProgress();
                }
            };
            
            _inputService.LoadProgress += () =>
            {
                if (_persistentDataService.Progress.LastDish == null)
                {
                    _loggingService.LogWarning("loading aborted, there's no last dish data!", this);
                }
                else
                {
                    _levelProgressService.LevelProgressWatcher.CurrentScore = _persistentDataService.Progress.Score;
                    _levelProgressService.LevelProgressWatcher.BestDishData = _persistentDataService.Progress.BestDish;
                    _levelProgressService.LevelProgressWatcher.LastDishData = _persistentDataService.Progress.LastDish;
                }
            };

            _inputService.ShowCombinations += () =>
            {
                _combinationsWindow.InitAndShow(_staticDataService.GetAllIngredients());
            };

            _inputService.ReturnToMenu += () =>
            {
                _stateMachine.Enter<LoadMetaState>();
            };
        }

        private void OnDestroy()
        {
            _inputService.ReloadScene      = null;
            _inputService.SaveProgress     = null;
            _inputService.LoadProgress     = null;
            _inputService.ShowCombinations = null;
        }
    }
}