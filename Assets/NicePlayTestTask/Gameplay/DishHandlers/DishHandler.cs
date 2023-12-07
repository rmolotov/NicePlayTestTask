using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace NicePlayTestTask.Gameplay.DishHandlers
{
    /// <summary>
    /// Chain of responsibility
    /// </summary>
    public class DishHandler : SerializedMonoBehaviour, IDishScoreHandler
    {
        [field: SerializeField] public IDishScoreHandler Successor { get; set; }
        
        public void Handle(Dictionary<string, int> ingredientsCounts)
        {
            // 1. handle by self:
            // todo
            // 2. send to successor if exists:
            Successor?.Handle(ingredientsCounts);
        }
    }
}