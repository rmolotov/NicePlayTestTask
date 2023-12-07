using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using NicePlayTestTask.Data;

namespace NicePlayTestTask.Gameplay.DishHandlers
{
    /// <summary>
    /// Chain of responsibility
    /// </summary>
    public class ComboHandler : BaseHandler
    {
        [CanBeNull]
        protected override string HandleBySelf(Dictionary<string, DishIngredientData> ingredients, string dishKey = null)
        {
            // all ingredients is unique
            if (ingredients.Values.All(i => i.Count == 1))
            {
                foreach (var key in ingredients.Keys)
                    ingredients[key].Cost *= StaticDataService.ForCombo(0).Multiplier;
                return dishKey;
            }
            
            foreach (var key in ingredients.Keys)
                ingredients[key].Cost *= StaticDataService.ForCombo(ingredients[key].Count).Multiplier;

            return dishKey;
        }
    }
}