using NicePlayTestTask.Gameplay.Logic;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;
using NicePlayTestTask.Infrastructure.Factorises.Interfaces;
using NicePlayTestTask.Services.Logging;

namespace NicePlayTestTask.Gameplay.Spawners
{
    public class IngredientSpawner : MonoBehaviour, IPointerDownHandler
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

        public void OnPointerDown(PointerEventData eventData)
        {
            Spawn();
        }

        private async void Spawn()
        {
            var ingredient = await _ingredientFactory.Create(ingredientKey, spawnPoint.position);
            ingredient.GetComponent<PointerFollow>().BeginDrag();
        }
    }
}