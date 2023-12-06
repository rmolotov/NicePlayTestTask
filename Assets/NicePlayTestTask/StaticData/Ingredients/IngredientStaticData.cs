using System;

namespace NicePlayTestTask.StaticData.Ingredients
{
    [Serializable]
    public record IngredientStaticData
    {
        public string Key { get; set; }
        public int Cost { get; set; }
    }
}