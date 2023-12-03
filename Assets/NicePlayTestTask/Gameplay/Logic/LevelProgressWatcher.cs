using NicePlayTestTask.Infrastructure.GameStateMachine;
using NicePlayTestTask.Services.Logging;
using UnityEngine;
using Zenject;

namespace NicePlayTestTask.Gameplay.Logic
{
    public class LevelProgressWatcher : MonoBehaviour
    {
        private GameStateMachine _gameStateMachine;
        private ILoggingService _loggingService;

        [Inject]
        private void Construct(GameStateMachine gameStateMachine, ILoggingService loggingService)
        {
            _gameStateMachine = gameStateMachine;
            _loggingService = loggingService;
        }

        public void RunLevel()
        {
            _loggingService.LogMessage($"level ran", this);
        }
    }
}