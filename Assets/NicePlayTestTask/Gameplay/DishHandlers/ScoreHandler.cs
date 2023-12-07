using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;
using NicePlayTestTask.Services.LevelProgress;
using NicePlayTestTask.Services.Logging;
using NicePlayTestTask.Services.StaticData;

namespace NicePlayTestTask.Gameplay.DishHandlers
{
    /// <summary>
    /// Chain of responsibility
    /// </summary>
    public class ScoreHandler : MonoBehaviour, IDishScoreHandler
    {
        private ILoggingService _loggingService;
        private IStaticDataService _staticDataService;
        private ILevelProgressService _levelProgressService;
        
        [field: SerializeField] public IDishScoreHandler Successor { get; set; }
        
        [Inject]
        private void Construct(
            ILoggingService logger, 
            IStaticDataService staticDataService,
            ILevelProgressService levelProgressService
        )
        {
            _loggingService = logger;
            _staticDataService = staticDataService;
            _levelProgressService = levelProgressService;
        }
        
        public void Handle(Dictionary<string, int> ingredientsCounts)
        {
            var totalScore = ingredientsCounts.Keys.Sum(key =>
                _staticDataService.ForIngredient(ingredientKey: key).Cost
                * ingredientsCounts[key]
            );
            
            _loggingService.LogMessage($"dish [{totalScore}] cooked", this);
            _levelProgressService.LevelProgressWatcher.CurrentScore += totalScore;
        }
    }
}