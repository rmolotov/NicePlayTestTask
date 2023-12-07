using System.Collections.Generic;
using JetBrains.Annotations;
using NicePlayTestTask.Data;

namespace NicePlayTestTask.Gameplay.DishHandlers
{
    /// <summary>
    /// Chain of responsibility
    /// </summary>
    public class CostHandler : BaseHandler
    {
        [CanBeNull]
        protected override string HandleBySelf(Dictionary<string, DishIngredientData> ingredients, string dishKey = null)
        {
            foreach (var ingredient in ingredients)
                ingredient.Value.Cost = StaticDataService.ForIngredient(ingredient.Key).Cost;

            return dishKey;
        }
    }
}