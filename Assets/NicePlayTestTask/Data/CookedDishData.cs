using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace NicePlayTestTask.Data
{
    [Serializable]
    public class CookedDishData
    {
        [CanBeNull] 
        public string DishKey { get; set; }
        public Dictionary<string, DishIngredientData> Ingredients { get; set; } = new();
    }
}