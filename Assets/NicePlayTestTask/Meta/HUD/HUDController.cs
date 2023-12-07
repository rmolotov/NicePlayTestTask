using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using NicePlayTestTask.Data;

namespace NicePlayTestTask.Meta.HUD
{
    public class HUDController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI bestDishText;
        [SerializeField] private TextMeshProUGUI lastDishText;
        [SerializeField] private Button restartButton;

        public void UpdateScore(int newScore) =>
            scoreText.text = newScore.ToString("0000");

        public void UpdateBestDish(CookedDishData newBestDish) => 
            bestDishText.text = ConstructText(newBestDish);

        public void UpdateLastDish(CookedDishData newLastDish) => 
            lastDishText.text = ConstructText(newLastDish);

        private static string ConstructText(CookedDishData dishData)
        {
            var text = $"{dishData.DishKey} (";
            text = dishData.Ingredients.Values
                .Aggregate(text, (current, ingredient) => current + $"{ingredient.Count} {ingredient.Key}, ")
                .TrimEnd(new[] { ' ', ',' });
            text += $") [{dishData.TotalCost}]";
            return text;
        }
    }
}