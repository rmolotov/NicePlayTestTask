using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;
using NicePlayTestTask.Services.Logging;
using NicePlayTestTask.Services.StaticData;
using NicePlayTestTask.Services.LevelProgress;
using NicePlayTestTask.StaticData.Ingredients;

namespace NicePlayTestTask.Gameplay.Cauldron
{
    public class Cauldron : MonoBehaviour
    {
        private ILoggingService _loggingService;
        private IStaticDataService _staticDataService;
        private ILevelProgressService _levelProgressService;

        private List<IngredientStaticData> _ingredients = new();

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

        public void AddIngredient(string ingredientKey)
        {
            var staticData = _staticDataService.ForIngredient(ingredientKey: ingredientKey);
            _ingredients.Add(staticData);
            
            _loggingService.LogMessage($"{ingredientKey} ({staticData.Cost}) added", this);
            
            if (_ingredients.Count == 5)
                Cook();
        }
        
        private void Cook()
        {
            var sum = _ingredients.Sum(i => i.Cost);
            
            _loggingService.LogMessage($"dish ({sum}) cooked", this);
            _levelProgressService.LevelProgressWatcher.CurrentScore += sum;
            
            _ingredients.Clear();
        }
    }
}