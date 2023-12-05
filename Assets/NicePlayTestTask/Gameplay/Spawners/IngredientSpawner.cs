using UnityEngine;
using Zenject;
using NicePlayTestTask.Infrastructure.Factorises.Interfaces;
using NicePlayTestTask.Services.Logging;
using NicePlayTestTask.Gameplay.Ingredients;

namespace NicePlayTestTask.Gameplay.Spawners
{
    public class IngredientSpawner : MonoBehaviour
    {
        private IIngredientFactory _ingredientFactory;
        private ILoggingService _logger;

        [SerializeField] private string ingredientKey;
        [SerializeField] private Transform spawnPoint;
        
        [Inject]
        private void Construct(IIngredientFactory ingredientFactory, ILoggingService loggingService)
        {
            _ingredientFactory = ingredientFactory;
            _logger = loggingService;
        }

        public void OnMouseDown()
        {
            Spawn();
        }

        private async void Spawn()
        {
            var ingredient = await _ingredientFactory.Create(ingredientKey, spawnPoint.position);
            ingredient.GetComponentInChildren<IngredientPointerFollow>().BeginDrag();
        }
    }
}