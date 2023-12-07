using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;
using Sirenix.OdinInspector;
using NicePlayTestTask.Data;
using NicePlayTestTask.Services.LevelProgress;
using NicePlayTestTask.Services.Logging;

namespace NicePlayTestTask.Gameplay.DishHandlers
{
    /// <summary>
    /// Chain of responsibility
    /// </summary>
    public class TotalScoreHandler : SerializedMonoBehaviour, IDishScoreHandler
    {
        private ILoggingService _loggingService;
        private ILevelProgressService _levelProgressService;
        
        [field: SerializeField] public IDishScoreHandler Successor { get; set; }
        
        [Inject]
        private void Construct(
            ILoggingService logger,
            ILevelProgressService levelProgressService
        )
        {
            _loggingService = logger;
            _levelProgressService = levelProgressService;
        }
        
        public void Handle(Dictionary<string, DishIngredientData> ingredients)
        {
            if (gameObject.activeInHierarchy)
                HandleBySelf(ingredients);
            Successor?.Handle(ingredients);
        }

        private void HandleBySelf(Dictionary<string, DishIngredientData> ingredients)
        {
            var totalScore = ingredients.Keys.Sum(key =>
                ingredients[key].Cost
                * ingredients[key].Count
            );

            _loggingService.LogMessage($"dish [{totalScore}] cooked", this);
            _levelProgressService.LevelProgressWatcher.CurrentScore += (int)totalScore;
        }
    }
}