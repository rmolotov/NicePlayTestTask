using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Zenject;
using NicePlayTestTask.Data;
using NicePlayTestTask.Services.LevelProgress;

namespace NicePlayTestTask.Meta.HUD
{
    public class HUDController : MonoBehaviour
    {
        private ILevelProgressService _levelProgressService;

        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI bestDishText;
        [SerializeField] private TextMeshProUGUI lastDishText;
        [SerializeField] private Button restartButton;

        [Inject]
        private void Construct(ILevelProgressService levelProgressService)
        {
            _levelProgressService = levelProgressService;
        }

        public void Initialize()
        {
            restartButton.onClick.AddListener(() =>
                _levelProgressService.LevelProgressWatcher.RestartLevel());
        }

        public void Reset()
        {
            scoreText.text = string.Empty;
            bestDishText.text = string.Empty;
            lastDishText.text = string.Empty;
        }

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