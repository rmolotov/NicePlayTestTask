using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Sirenix.OdinInspector;
using NicePlayTestTask.Services.Logging;
using NicePlayTestTask.Gameplay.DishHandlers;

namespace NicePlayTestTask.Gameplay.Cauldron
{
    public class Cauldron : SerializedMonoBehaviour
    {
        private const int CauldronCapacity = 5;
        
        private ILoggingService _loggingService;
        
        [SerializeField, Required] private IDishScoreHandler headOfHandlersChain;

        private List<string> _ingredients = new(CauldronCapacity);


        [Inject]
        private void Construct(ILoggingService logger)
        {
            _loggingService = logger;
        }

        public void AddIngredient(string ingredientKey)
        {
            _ingredients.Add(ingredientKey);
            _loggingService.LogMessage($"{ingredientKey} added", this);
            
            if (_ingredients.Count == CauldronCapacity)
                Cook();
        }
        
        private void Cook()
        {
            var uniqueIngredients = new Dictionary<string, int>();
            foreach (var ingredient in _ingredients)
                uniqueIngredients[ingredient] = uniqueIngredients.TryGetValue(ingredient, out var value)
                    ? value + 1
                    : 1;
            
            headOfHandlersChain.Handle(uniqueIngredients);
            _ingredients.Clear();
        }
    }
}