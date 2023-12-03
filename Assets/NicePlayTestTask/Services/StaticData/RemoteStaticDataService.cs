using System;
using NicePlayTestTask.Services.Logging;
using NicePlayTestTask.StaticData.Ingredients;

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
    }
}