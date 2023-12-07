using NicePlayTestTask.Data;

namespace NicePlayTestTask.Gameplay.DishHandlers
{
    /// <summary>
    /// Chain of responsibility
    /// </summary>
    public class CostHandler : BaseHandler
    {
        protected override void HandleBySelf(CookedDishData dishData)
        {
            foreach (var ingredient in dishData.Ingredients)
                ingredient.Value.Cost = StaticDataService.ForIngredient(ingredient.Key).Cost;
        }
    }
}