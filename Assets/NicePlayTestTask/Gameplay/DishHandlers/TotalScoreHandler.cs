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
        
        protected override void HandleBySelf(CookedDishData dishData)
        {
            dishData.TotalCost = (int)dishData.Ingredients.Keys.Sum(key =>
                dishData.Ingredients[key].Cost
                * dishData.Ingredients[key].Count
            );
            
            
            _levelProgressService.LevelProgressWatcher.CurrentScore += dishData.TotalCost;

            _levelProgressService.LevelProgressWatcher.LastDishData = dishData;

            if (_levelProgressService.LevelProgressWatcher.BestDishData == null 
                || dishData.TotalCost > _levelProgressService.LevelProgressWatcher.BestDishData.TotalCost)
                _levelProgressService.LevelProgressWatcher.BestDishData = dishData;
            
            
            _loggingService.LogMessage($"{dishData.DishKey} [{dishData.TotalCost}] cooked", this);
        }
    }
}