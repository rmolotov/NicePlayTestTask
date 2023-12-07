using System.Collections.Generic;
using System.Linq;
using Zenject;
using NicePlayTestTask.Data;
using NicePlayTestTask.Services.LevelProgress;
using NicePlayTestTask.Services.Logging;

namespace NicePlayTestTask.Gameplay.DishHandlers
{
    /// <summary>
    /// Chain of responsibility
    /// </summary>
    public class TotalScoreHandler : BaseHandler
    {
        private ILoggingService _loggingService;
        private ILevelProgressService _levelProgressService;

        [Inject]
        private void Construct(ILoggingService logger, ILevelProgressService levelProgressService)
        {
            _loggingService = logger;
            _levelProgressService = levelProgressService;
        }
        
        protected override void HandleBySelf(Dictionary<string, DishIngredientData> ingredients)
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