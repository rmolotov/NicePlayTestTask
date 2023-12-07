using System;

namespace NicePlayTestTask.Data
{
    [Serializable]
    public class DishIngredientData
    {
        public DishIngredientData(string key, int cost = 0, float multiplier = 1f, int count = 1) =>
            (Key, BaseCost, Multiplier, Count) = (key, cost, multiplier, count);
        
        public string Key { get; set; }
        public int BaseCost { get; set; }
        public float Multiplier { get; set; }
        public int Count { get; set; }
    }
}