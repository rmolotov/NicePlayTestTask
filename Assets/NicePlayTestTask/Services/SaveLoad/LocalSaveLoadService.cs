using System.Threading.Tasks;
using UnityEngine;
using NicePlayTestTask.Data;
using NicePlayTestTask.Services.PersistentData;

using static Newtonsoft.Json.JsonConvert;

namespace NicePlayTestTask.Services.SaveLoad
{
    public class LocalSaveLoadService : ISaveLoadService
    {
        private const string ProgressKey = "Progress";
        
        private readonly IPersistentDataService _persistentDataService;

        public LocalSaveLoadService(IPersistentDataService persistentDataService)
        {
            _persistentDataService = persistentDataService;
        }
        
        public void SaveProgress()
        {
            var progress = SerializeObject(_persistentDataService.Progress);
            PlayerPrefs.SetString(ProgressKey, progress);
        }

        public Task<PlayerProgressData> LoadProgress()
        {
            var progress = DeserializeObject<PlayerProgressData>(PlayerPrefs.GetString(ProgressKey));
            return Task.FromResult(progress);
        }
    }
}