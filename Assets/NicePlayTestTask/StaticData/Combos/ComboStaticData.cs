using System;

namespace NicePlayTestTask.StaticData.Combos
{
    [Serializable]
    public record ComboStaticData
    {
        public int SameIngredientCount { get; set; }
        public float Multiplier { get; set; }
    }
}