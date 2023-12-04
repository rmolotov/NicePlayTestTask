using System;
using System.Collections.Generic;
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

        List<IngredientStaticData> GetAllIngredients();
        List<ComboStaticData> GetAllCombos();
        List<RecipeStaticData> GetAllRecipes ();
    }
}