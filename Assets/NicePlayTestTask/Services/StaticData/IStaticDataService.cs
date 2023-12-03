using System;
using Zenject;
using NicePlayTestTask.StaticData.Ingredients;

namespace NicePlayTestTask.Services.StaticData
{
    public interface IStaticDataService : IInitializable
    {
        Action Initialized { get; set; }

        IngredientStaticData ForIngredient(string ingredientKey);
    }
}