using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using UnityEngine;
using TMPro;
using Zenject;
using NicePlayTestTask.Data;
using NicePlayTestTask.Services.StaticData;
using NicePlayTestTask.Tools.CustomExtensions;
using NicePlayTestTask.UI.Windows;
using NicePlayTestTask.StaticData.Ingredients;
using NicePlayTestTask.StaticData.Recipes;

namespace NicePlayTestTask.Meta.CombinationsList
{
    public class CombinationsWindow : OneButtonWindow
    {
        private const string DefaultRecipeKey = "Soup";
        
        private IStaticDataService _staticDataService;

        [SerializeField] private TextMeshProUGUI combinationsText;
        private bool _initialized = false;

        private List<IngredientStaticData> _ingredients;

        [Inject]
        private void Construct(IStaticDataService staticDataService) => 
            _staticDataService = staticDataService;

        public override TaskCompletionSource<bool> InitAndShow<T>(T data, string titleText = "")
        {
            if (_initialized == false)
            {
                _ingredients = data as List<IngredientStaticData>;
                
                var rawKeys = CalculateCombinations();
                
                var dishes = GenerateDishes(rawKeys);
                dishes = FillBaseCost(dishes);
                dishes = CalculateCombos(dishes);
                dishes = FillRecipes(dishes);
                dishes = FillTotalScore(dishes);

                dishes = dishes
                    .OrderByDescending(d => d.TotalCost)
                    .ToList();
                
                PrintDishes(dishes);

                titleText = $"Combinations list ({dishes.Count})";
                
                _initialized = true;
            }
            
            return base.InitAndShow(data, titleText);
        }

        private List<IEnumerable<string>> CalculateCombinations() =>
            EnumerableExtensions
                .GetKCombosWithRepetition(
                    _ingredients.Select(i => i.Key),
                    5)
                .ToList();


        // copied from Cauldron Behavior
        private List<CookedDishData> GenerateDishes(List<IEnumerable<string>> combos)
        {
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

        // copied from CostHandler
        private List<CookedDishData> FillBaseCost(List<CookedDishData> dishes)
        {
            foreach (var dishData in dishes)
            foreach (var ingredient in dishData.Ingredients)
                ingredient.Value.BaseCost = _staticDataService.ForIngredient(ingredient.Key).Cost;

            return dishes;
        }

        // copied from ComboHandler
        private List<CookedDishData> CalculateCombos(List<CookedDishData> dishes)
        {
            foreach (var dishData in dishes)
            {
                // all ingredients is unique
                if (dishData.Ingredients.Values.All(i => i.Count == 1))
                    foreach (var key in dishData.Ingredients.Keys)
                        dishData.Ingredients[key].Multiplier =
                            _staticDataService.ForCombo(1).Multiplier;
                else
                    foreach (var key in dishData.Ingredients.Keys)
                        dishData.Ingredients[key].Multiplier =
                            _staticDataService.ForCombo(dishData.Ingredients[key].Count).Multiplier;
            }

            return dishes;
        }

        // copied from RecipeHandler
        private List<CookedDishData> FillRecipes(List<CookedDishData> dishes)
        {
            foreach (var dishData in dishes)
            {
                dishData.DishKey = DefaultRecipeKey;
                foreach (var recipeKey in _staticDataService
                             .GetAllRecipes()
                             .Select(recipe => CheckRecipe(recipe, dishData.Ingredients))
                             .Where(recipeKey => recipeKey != null))
                {
                    dishData.DishKey = recipeKey;
                    break;
                }
            }

            return dishes;
        }
        
        // copied from TotalScoreHandler
        private List<CookedDishData> FillTotalScore(List<CookedDishData> dishes)
        {
            foreach (var dishData in dishes)
                dishData.TotalCost = (int)dishData.Ingredients.Keys.Sum(key =>
                    dishData.Ingredients[key].BaseCost
                    * dishData.Ingredients[key].Count
                    * dishData.Ingredients[key].Multiplier
                );

            return dishes;
        }
        

        private void PrintDishes(List<CookedDishData> dishes)
        {
            var result = new List<string>();

            foreach (var dish in dishes)
            {
                var text = string.Empty;
                
                foreach (var ingredient in dish.Ingredients)
                    text += $"{ingredient.Value.Count} {ingredient.Value.Key}, ";
                
                text = $"({text.TrimEnd(',', ' ')}) <b>[{dish.TotalCost}]</b>";
                text = $"<b>{dish.DishKey}</b> " + text;
                
                result.Add(text);
            }
            
            combinationsText.text = string.Join('\n', result);
        }

        [CanBeNull]
        private string CheckRecipe(RecipeStaticData recipe, Dictionary<string, DishIngredientData> ingredients) =>
            recipe.Ingredients.All(targetIngredient =>
                (ingredients.ContainsKey(targetIngredient.Key)
                 && targetIngredient.Value[0] <= ingredients[targetIngredient.Key].Count
                 && targetIngredient.Value[1] >= ingredients[targetIngredient.Key].Count)
                || (targetIngredient.Value[1] == 0 && ingredients.ContainsKey(targetIngredient.Key) == false)
            )
                ? recipe.Key
                : null;
    }
}