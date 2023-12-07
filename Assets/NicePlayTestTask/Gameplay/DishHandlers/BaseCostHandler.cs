using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Sirenix.OdinInspector;
using NicePlayTestTask.Data;
using NicePlayTestTask.Services.StaticData;

namespace NicePlayTestTask.Gameplay.DishHandlers
{
    /// <summary>
    /// Chain of responsibility
    /// </summary>
    public class BaseCostHandler : SerializedMonoBehaviour, IDishScoreHandler
    {
        private IStaticDataService _staticDataService;
        
        [field: SerializeField] public IDishScoreHandler Successor { get; set; }
        
        [Inject]
        private void Construct(IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
        }
        
        public void Handle(Dictionary<string, DishIngredientData> ingredients)
        {
            if (gameObject.activeInHierarchy)
                HandleBySelf(ingredients);
            Successor?.Handle(ingredients);
        }

        private void HandleBySelf(Dictionary<string, DishIngredientData> ingredients)
        {
            foreach (var ingredient in ingredients)
                ingredient.Value.Cost = _staticDataService.ForIngredient(ingredient.Key).Cost;
        }
    }
}