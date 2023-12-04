using System;
using System.Collections.Generic;

namespace NicePlayTestTask.Data
{
    [Serializable]
    public class PlayerProgressData
    {
        public int Score { get; set; }
        public Dictionary<string, int> BestDish { get; set; }
        public Dictionary<string, int> LastDish { get; set; }
        public HashSet<string> UnlockedRecipes { get; set; }
    }
}