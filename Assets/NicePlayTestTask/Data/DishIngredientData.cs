using System;

namespace NicePlayTestTask.Data
{
    [Serializable]
    public class DishIngredientData
    {
        public DishIngredientData(string key, int cost = 0, int count = 1) =>
            (Key, Cost, Count) = (key, cost, count);
        
        public string Key { get; set; }
        public float Cost { get; set; }
        public int Count { get; set; }
    }
}