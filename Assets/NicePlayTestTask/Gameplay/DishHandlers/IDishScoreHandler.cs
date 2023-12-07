using System.Collections.Generic;

namespace NicePlayTestTask.Gameplay.DishHandlers
{
    /// <summary>
    /// Chain of responsibility
    /// </summary>
    public interface IDishScoreHandler
    {
        IDishScoreHandler Successor { get; set; }
        void Handle(Dictionary<string, int> ingredientsCounts);
    }
}