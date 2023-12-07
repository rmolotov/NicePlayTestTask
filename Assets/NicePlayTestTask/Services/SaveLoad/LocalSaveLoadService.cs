using System.Threading.Tasks;
using UnityEngine;
using NicePlayTestTask.Data;
using NicePlayTestTask.Services.Logging;
using NicePlayTestTask.Services.PersistentData;

using static Newtonsoft.Json.JsonConvert;

namespace NicePlayTestTask.Services.SaveLoad
{
    public class LocalSaveLoadService : ISaveLoadService
    {
        private const string ProgressKey = "Progress";
        
        private readonly IPersistentDataService _persistentDataService;
        private readonly ILoggingService _loggingService;

        public LocalSaveLoadService(IPersistentDataService persistentDataService, ILoggingService loggingService)
        {
            _persistentDataService = persistentDataService;
            _loggingService = loggingService;
        }
        
        public void SaveProgress()
        {
            var progress = SerializeObject(_persistentDataService.Progress);
            PlayerPrefs.SetString(ProgressKey, progress);
            
            _loggingService.LogMessage("progress saved", this);
        }

        public Task<PlayerProgressData> LoadProgress()
        {
            var progress = DeserializeObject<PlayerProgressData>(PlayerPrefs.GetString(ProgressKey));
            
            _loggingService.LogMessage("progress loaded", this);
            return Task.FromResult(progress);
        }
    }
}