using System.Linq;
using NicePlayTestTask.Data;

namespace NicePlayTestTask.Gameplay.DishHandlers
{
    /// <summary>
    /// Chain of responsibility
    /// </summary>
    public class ComboHandler : BaseHandler
    {
        protected override void HandleBySelf(CookedDishData dishData)
        {
            // all ingredients is unique
            if (dishData.Ingredients.Values.All(i => i.Count == 1))
            {
                foreach (var key in dishData.Ingredients.Keys)
                    dishData.Ingredients[key].Multiplier = StaticDataService.ForCombo(0).Multiplier;
            }
            
            foreach (var key in dishData.Ingredients.Keys)
                dishData.Ingredients[key].Multiplier = StaticDataService.ForCombo(dishData.Ingredients[key].Count).Multiplier;
        }
    }
}