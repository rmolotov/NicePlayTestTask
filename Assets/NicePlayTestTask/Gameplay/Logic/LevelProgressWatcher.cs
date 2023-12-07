using System;
using UnityEngine;
using Zenject;
using NicePlayTestTask.Data;
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

        #region Best dish Rx Property

        private CookedDishData _bestDishData;

        public CookedDishData BestDishData
        {
            get => _bestDishData;
            set => BestDishChanged?.Invoke(_bestDishData = value);
        }
        public event Action<CookedDishData> BestDishChanged; 

        #endregion
        
        #region Last dish Rx Property

        private CookedDishData _lastDishData;

        public CookedDishData LastDishData
        {
            get => _lastDishData;
            set => LastDishChanged?.Invoke(_lastDishData = value);
        }
        public event Action<CookedDishData> LastDishChanged; 

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