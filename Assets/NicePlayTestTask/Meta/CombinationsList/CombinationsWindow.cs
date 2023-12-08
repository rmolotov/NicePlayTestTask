using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using TMPro;
using NicePlayTestTask.Data;
using NicePlayTestTask.Tools.CustomExtensions;
using NicePlayTestTask.UI.Windows;
using NicePlayTestTask.StaticData.Ingredients;

namespace NicePlayTestTask.Meta.CombinationsList
{
    public class CombinationsWindow : OneButtonWindow
    {
        private List<IngredientStaticData> _ingredients;
        
        [SerializeField] private TextMeshProUGUI combinationsText;
        private bool _initialized = false;

        public override TaskCompletionSource<bool> InitAndShow<T>(T data, string titleText = "")
        {
            if (_initialized == false)
            {
                _ingredients = data as List<IngredientStaticData>;
                
                var dishes = CalculateCombinations();
                PrintCombinations(dishes);

                titleText = $"Combinations list ({dishes.Count})";
                
                _initialized = true;
            }
            
            return base.InitAndShow(data, titleText);
        }

        private List<CookedDishData> CalculateCombinations()
        {
            var combos =  EnumerableExtensions
                .GetKCombosWithRepetition(
                    _ingredients.Select(i => i.Key),
                    5)
                .ToList();

            var result = new List<CookedDishData>();
            
            foreach (var dish in combos)
            {
                var dishData = new CookedDishData();

                foreach (var ingredient in dish)
                    dishData.Ingredients[ingredient] = dishData.Ingredients.TryGetValue(ingredient, out var value)
                        ? value.With(v => v.Count++)
                        : new DishIngredientData(ingredient);
                
                result.Add(dishData);
            }

            return result;
        }

        private void PrintCombinations(List<CookedDishData> dishes)
        {
            var result = string.Empty;

            foreach (var dish in dishes)
            {
                foreach (var ingredient in dish.Ingredients)
                {
                    result += $"{ingredient.Value.Count} {ingredient.Value.Key}, ";
                }
                result = result.TrimEnd(',', ' ') + " []\n";
            }
            
            combinationsText.text = result;
        }
    }
}