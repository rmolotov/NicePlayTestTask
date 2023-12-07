using UnityEngine;
using Zenject;
using NicePlayTestTask.Services.Input;
using NicePlayTestTask.Services.LevelProgress;

namespace NicePlayTestTask.Gameplay.Logic
{
    public class HotkeyWatcher : MonoBehaviour
    {
        private IInputService _inputService;
        private ILevelProgressService _progressService;

        [Inject]
        private void Construct(IInputService inputService, ILevelProgressService progressService)
        {
            _inputService = inputService;
            _progressService = progressService;
        }
        
        private void Start()
        {
            _inputService.ReloadScene += _progressService.LevelProgressWatcher.RestartLevel;
            // todo: load from save
            // todo: show combinations
        }

        private void OnDestroy()
        {
            _inputService.ReloadScene = null;
        }
    }
}