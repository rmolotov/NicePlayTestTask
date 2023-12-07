using UnityEngine;
using Zenject;
using NicePlayTestTask.Services.Input;
using NicePlayTestTask.Services.PersistentData;
using NicePlayTestTask.Services.LevelProgress;
using NicePlayTestTask.Services.SaveLoad;

namespace NicePlayTestTask.Gameplay.Logic
{
    public class HotkeyWatcher : MonoBehaviour
    {
        private IInputService _inputService;
        private IPersistentDataService _persistentDataService;
        private ILevelProgressService _levelProgressService;
        private ISaveLoadService _saveLoadService;

        [Inject]
        private void Construct(
            IInputService inputService,
            IPersistentDataService persistentDataService,
            ILevelProgressService levelProgressService,
            ISaveLoadService saveLoadService)
        {
            _inputService = inputService;
            _persistentDataService = persistentDataService;
            _levelProgressService = levelProgressService;
            _saveLoadService = saveLoadService;
        }

        private void Start()
        {
            _inputService.ReloadScene  += _levelProgressService.LevelProgressWatcher.RestartLevel;
            
            _inputService.SaveProgress += () =>
            {
                _persistentDataService.Progress.Score    = _levelProgressService.LevelProgressWatcher.CurrentScore;
                _persistentDataService.Progress.BestDish = _levelProgressService.LevelProgressWatcher.BestDishData;
                _persistentDataService.Progress.LastDish = _levelProgressService.LevelProgressWatcher.LastDishData;
                
                _saveLoadService.SaveProgress();
            };
            
            _inputService.LoadProgress += () =>
            {
                _levelProgressService.LevelProgressWatcher.CurrentScore = _persistentDataService.Progress.Score;
                _levelProgressService.LevelProgressWatcher.BestDishData = _persistentDataService.Progress.BestDish;
                _levelProgressService.LevelProgressWatcher.LastDishData = _persistentDataService.Progress.LastDish;
                
                _saveLoadService.SaveProgress();
            };
            
            // todo: show combinations
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