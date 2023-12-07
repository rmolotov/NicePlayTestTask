using System.Collections.Generic;
using NicePlayTestTask.Data;

namespace NicePlayTestTask.Gameplay.DishHandlers
{
    /// <summary>
    /// Chain of responsibility
    /// </summary>
    public class CostHandler : BaseHandler
    {
        protected override void HandleBySelf(Dictionary<string, DishIngredientData> ingredients)
        {
            foreach (var ingredient in ingredients)
                ingredient.Value.Cost = StaticDataService.ForIngredient(ingredient.Key).Cost;
        }
    }
}