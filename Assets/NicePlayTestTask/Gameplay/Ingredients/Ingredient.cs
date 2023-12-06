using UnityEngine;

namespace NicePlayTestTask.Gameplay.Ingredients
{
    public class Ingredient : MonoBehaviour
    {
        [field: SerializeField] public string IngredientKey { get; private set; }
    }
}