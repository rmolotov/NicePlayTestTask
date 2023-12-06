using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace NicePlayTestTask.Meta.HUD
{
    public class HUDController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private Button restartButton;

        public void UpdateScore(int newScore) =>
            scoreText.text = newScore.ToString("0000");
    }
}