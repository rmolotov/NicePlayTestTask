using System.Collections.Generic;
using NicePlayTestTask.Data;

namespace NicePlayTestTask.Gameplay.DishHandlers
{
    /// <summary>
    /// Chain of responsibility
    /// </summary>
    public interface IDishScoreHandler
    {
        IDishScoreHandler Successor { get; set; }
        void Handle(Dictionary<string, DishIngredientData> ingredients);
    }
}