using System.Threading.Tasks;
using UnityEngine;
using Unity.Mathematics;
using Zenject;
using NicePlayTestTask.Infrastructure.AssetManagement;
using NicePlayTestTask.Infrastructure.Factorises.Interfaces;
using NicePlayTestTask.Services.StaticData;

namespace NicePlayTestTask.Infrastructure.Factorises
{
    public class IngredientFactory : IIngredientFactory
    {
        private const string IngredientKeyPrefix = "Ingredient";

        private readonly DiContainer _container;
        private readonly IAssetProvider _assetProvider;
        private readonly IStaticDataService _staticDataService;

        public IngredientFactory(
            DiContainer container, 
            IAssetProvider assetProvider, 
            IStaticDataService staticDataService)
        {
            _container = container;
            _assetProvider = assetProvider;
            _staticDataService = staticDataService;
        }

        public async Task WarmUp()
        {
            foreach (var ingredientStaticData in _staticDataService.GetAllIngredients())
                await _assetProvider.Load<GameObject>(key: IngredientKeyPrefix + ingredientStaticData.Key);
        }

        public void CleanUp()
        {
            foreach (var ingredientStaticData in _staticDataService.GetAllIngredients()) 
                _assetProvider.Release(key: IngredientKeyPrefix + ingredientStaticData.Key);
        }

        public async Task<GameObject> Create(string key, Vector2 at)
        {
            var prefab = await _assetProvider.Load<GameObject>(key: IngredientKeyPrefix + key);
            var ingredient = Object.Instantiate(prefab, at, quaternion.identity);
            
            _container.InjectGameObject(ingredient);

            return ingredient;
        }
    }
}