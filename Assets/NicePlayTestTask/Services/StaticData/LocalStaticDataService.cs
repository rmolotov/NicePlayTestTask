using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using NicePlayTestTask.Infrastructure.AssetManagement;
using NicePlayTestTask.StaticData.Combos;
using NicePlayTestTask.StaticData.Ingredients;
using NicePlayTestTask.StaticData.Recipes;

using static Newtonsoft.Json.JsonConvert;

namespace NicePlayTestTask.Services.StaticData
{
    public class LocalStaticDataService : IStaticDataService
    {
        private const string IngredientsListKey = "IngredientsList";
        private const string CombosListKey      = "CombosList";
        private const string RecipesListKey     = "RecipesList";
        
        private readonly IAssetProvider _assetProvider;

        private Dictionary<string, IngredientStaticData> _ingredients;
        private Dictionary<int, ComboStaticData> _combos;
        private Dictionary<string, RecipeStaticData> _recipes;

        public Action Initialized { get; set; }


        public LocalStaticDataService(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public async void Initialize()
        {
            await Task.WhenAll(
                LoadIngredients(),
                LoadCombos(),
                LoadRecipes()
            );
            
            Initialized?.Invoke();
        }

        
        public IngredientStaticData ForIngredient(string ingredientKey) =>
            _ingredients.TryGetValue(ingredientKey, out var ingredientData)
                ? ingredientData
                : null;
        
        public ComboStaticData ForCombo(int sameIngredientCount) =>
            _combos.TryGetValue(sameIngredientCount, out var comboData)
                ? comboData
                : null;
        
        public RecipeStaticData ForRecipe(string recipeKey) =>
            _recipes.TryGetValue(recipeKey, out var recipeData)
                ? recipeData
                : null;

        public List<IngredientStaticData> GetAllIngredients() =>
            _ingredients.Values.ToList();
        
        public List<ComboStaticData> GetAllCombos() =>
            _combos.Values.ToList();
        
        public List<RecipeStaticData> GetAllRecipes() =>
            _recipes.Values.ToList();

        
        private async Task LoadIngredients()
        {
            var jsonData = await _assetProvider.Load<TextAsset>(key: IngredientsListKey);
            var list = DeserializeObject<List<IngredientStaticData>>(jsonData.ToString());
            
            _ingredients = list.ToDictionary(x => x.Key, x => x);
        }
        
        private async Task LoadCombos()
        {
            var jsonData = await _assetProvider.Load<TextAsset>(key: CombosListKey);
            var list = DeserializeObject<List<ComboStaticData>>(jsonData.ToString());
            
            _combos = list.ToDictionary(x => x.SameIngredientCount, x => x);
        }
        
        private async Task LoadRecipes()
        {
            var jsonData = await _assetProvider.Load<TextAsset>(key: RecipesListKey);
            var list = DeserializeObject<List<RecipeStaticData>>(jsonData.ToString());
            
            _recipes = list.ToDictionary(x => x.Key, x => x);
        }
    }
}