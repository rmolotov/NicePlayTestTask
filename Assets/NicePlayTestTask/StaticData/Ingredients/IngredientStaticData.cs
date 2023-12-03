using System;

namespace NicePlayTestTask.StaticData.Ingredients
{
    [Serializable]
    public record IngredientStaticData
    {
        public string Key { get; set; }
        public string Cost { get; set; }
    }
}