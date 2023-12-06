using System;
using UnityEngine;
using Zenject;
using NicePlayTestTask.Infrastructure.GameStateMachine;
using NicePlayTestTask.Services.Logging;

namespace NicePlayTestTask.Gameplay.Logic
{
    public class LevelProgressWatcher : MonoBehaviour
    {
        private GameStateMachine _gameStateMachine;
        private ILoggingService _loggingService;

        #region Score Rx Property

        private int _currentScore;
        public int CurrentScore
        {
            get => _currentScore;
            set => ScoreChanged?.Invoke(_currentScore = value);
        }
        public event Action<int> ScoreChanged;

        #endregion


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