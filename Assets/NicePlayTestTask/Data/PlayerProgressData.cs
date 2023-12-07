using System;
using System.Collections.Generic;

namespace NicePlayTestTask.Data
{
    [Serializable]
    public class PlayerProgressData
    {
        public int Score { get; set; }
        public CookedDishData BestDish { get; set; }
        public CookedDishData LastDish { get; set; }
        public HashSet<string> UnlockedRecipes { get; set; }
    }
}