using NicePlayTestTask.Data;

namespace NicePlayTestTask.Services.PersistentData
{
    public interface IPersistentDataService
    {
        PlayerProgressData Progress { get; set; }
    }
}