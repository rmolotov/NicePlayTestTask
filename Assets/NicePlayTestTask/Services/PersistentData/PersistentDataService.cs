using NicePlayTestTask.Data;

namespace NicePlayTestTask.Services.PersistentData
{
    public class PersistentDataService : IPersistentDataService
    {
        public PlayerProgressData Progress { get; set; }
    }
}