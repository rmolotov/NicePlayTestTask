using System.Threading.Tasks;
using NicePlayTestTask.Data;

namespace NicePlayTestTask.Services.SaveLoad
{
    public interface ISaveLoadService
    {
        void SaveProgress();
        Task<PlayerProgressData> LoadProgress();
    }
}