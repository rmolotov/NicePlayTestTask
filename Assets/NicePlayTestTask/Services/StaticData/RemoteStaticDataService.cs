using System;
using NicePlayTestTask.Services.Logging;
using NicePlayTestTask.StaticData.Combos;
using NicePlayTestTask.StaticData.Ingredients;
using NicePlayTestTask.StaticData.Recipes;

namespace NicePlayTestTask.Services.StaticData
{
    public class RemoteStaticDataService : IStaticDataService
    {
        private const string ConfigEnvironmentId =
            "development"; // development
        //"production"; //production

        private readonly ILoggingService _logger;
        

        #region Attributes structs

        private struct UserAttributes
        {
        }

        private struct AppAttributes
        {
        }

        #endregion

        public Action Initialized { get; set; }

        public RemoteStaticDataService(ILoggingService loggingService) =>
            _logger = loggingService;

        public void Initialize()
        {
            // load configs from Unity.Services.RemoteConfig
        }

        public IngredientStaticData ForIngredient(string ingredientKey)
        {
            throw new NotImplementedException();
        }

        public ComboStaticData ForCombo(int sameIngredientCount)
        {
            throw new NotImplementedException();
        }

        public RecipeStaticData ForRecipe(string recipeKey)
        {
            throw new NotImplementedException();
        }
    }
}