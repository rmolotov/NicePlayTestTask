using System;
using System.Collections.Generic;
using UnityEngine;

namespace NicePlayTestTask.StaticData.Recipes
{
    [Serializable]
    public record RecipeStaticData
    {
        public string Key { get; set; }
        public Dictionary<string, int[]> Ingredients { get; set; }
    }
}