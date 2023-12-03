using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using NicePlayTestTask.Infrastructure.AssetManagement;
using NicePlayTestTask.StaticData.Ingredients;

using static Newtonsoft.Json.JsonConvert;

namespace NicePlayTestTask.Services.StaticData
{
    public class LocalStaticDataService : IStaticDataService
    {
        private const string IngredientsListKey = "IngredientsList";
        
        private readonly IAssetProvider _assetProvider;

        private Dictionary<string, IngredientStaticData> _ingredients;

        public Action Initialized { get; set; }


        public LocalStaticDataService(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public async void Initialize()
        {
            await Task.WhenAll(
                LoadIngredients()
            );
            
            Initialized?.Invoke();
        }

        public IngredientStaticData ForIngredient(string ingredientKey) =>
            _ingredients.TryGetValue(ingredientKey, out var ingredientData)
                ? ingredientData
                : null;

        
        private async Task LoadIngredients()
        {
            var jsonData = await _assetProvider.Load<TextAsset>(key: IngredientsListKey);
            var list = DeserializeObject<List<IngredientStaticData>>(jsonData.ToString());
            
            _ingredients = list.ToDictionary(x => x.Key, x => x);
        }
    }
}