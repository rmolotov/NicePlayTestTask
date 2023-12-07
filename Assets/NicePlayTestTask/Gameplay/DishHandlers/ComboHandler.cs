using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Sirenix.OdinInspector;
using Zenject;
using NicePlayTestTask.Data;
using NicePlayTestTask.Services.StaticData;

namespace NicePlayTestTask.Gameplay.DishHandlers
{
    /// <summary>
    /// Chain of responsibility
    /// </summary>
    public class ComboHandler : SerializedMonoBehaviour, IDishScoreHandler
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
            // all ingredients is unique
            if (ingredients.Values.All(i => i.Count == 1))
            {
                foreach (var key in ingredients.Keys)
                    ingredients[key].Cost *= _staticDataService.ForCombo(0).Multiplier;
                return;
            }
            
            foreach (var key in ingredients.Keys)
                ingredients[key].Cost *= _staticDataService.ForCombo(ingredients[key].Count).Multiplier;
        }
    }
}