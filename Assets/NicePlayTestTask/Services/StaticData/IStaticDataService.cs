using System;
using Zenject;
using NicePlayTestTask.StaticData.Combos;
using NicePlayTestTask.StaticData.Ingredients;
using NicePlayTestTask.StaticData.Recipes;

namespace NicePlayTestTask.Services.StaticData
{
    public interface IStaticDataService : IInitializable
    {
        Action Initialized { get; set; }

        IngredientStaticData ForIngredient(string ingredientKey);
        ComboStaticData ForCombo(int sameIngredientCount);
        RecipeStaticData ForRecipe(string recipeKey);
    }
}