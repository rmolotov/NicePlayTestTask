using UnityEngine;
using NicePlayTestTask.Gameplay.Logic;
using NicePlayTestTask.Gameplay.Ingredients;

namespace NicePlayTestTask.Gameplay.Cauldron.Components
{
    public class CauldronIngredientHandler : MonoBehaviour
    {
        [SerializeField] private TriggerObserver ingredientObserver;
        [SerializeField] private Cauldron cauldron;
        
        private void Start() => 
            ingredientObserver.TriggerEnter += OnIngredientTriggerEnter;

        private void OnDestroy() => 
            ingredientObserver.TriggerEnter -= OnIngredientTriggerEnter;

        private void OnIngredientTriggerEnter(Collider2D other)
        {
            other.TryGetComponent(out Ingredient ingredient);
            
            cauldron.AddIngredient(ingredient.IngredientKey);
            Destroy(other.gameObject);
        }
    }
}