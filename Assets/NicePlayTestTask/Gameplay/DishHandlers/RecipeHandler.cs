using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Zenject;
using NicePlayTestTask.Data;
using NicePlayTestTask.Services.LevelProgress;
using NicePlayTestTask.Services.Logging;
using NicePlayTestTask.StaticData.Recipes;

namespace NicePlayTestTask.Gameplay.DishHandlers
{
    public class RecipeHandler : BaseHandler
    {
        private const string DefaultRecipeKey = "Soup";

        private ILoggingService _loggingService;
        private ILevelProgressService _levelProgressService;


        [Inject]
        private void Construct(
            ILoggingService logger,
            ILevelProgressService levelProgressService
        )
        {
            _loggingService = logger;
            _levelProgressService = levelProgressService;
        }

        protected override void HandleBySelf(Dictionary<string, DishIngredientData> ingredients)
        {
            // check recipes
            foreach (var recipeKey in StaticDataService
                         .GetAllRecipes()
                         .Select(recipe => CheckRecipe(recipe, ingredients))
                         .Where(recipeKey => recipeKey != null))
            {
                ReportRecipe(recipeKey);
                return;
            }

            // report default
            ReportRecipe(DefaultRecipeKey);
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

        private void ReportRecipe(string recipeKey)
        {
            _loggingService.LogMessage($"{recipeKey} cooked", this);
        }
    }
}