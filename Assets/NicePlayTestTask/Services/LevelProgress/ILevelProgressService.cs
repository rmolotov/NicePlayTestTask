using NicePlayTestTask.Gameplay.Logic;

namespace NicePlayTestTask.Services.LevelProgress
{
    public interface ILevelProgressService
    {
        LevelProgressWatcher LevelProgressWatcher { get; set; }
        
        void InitForLevel(LevelProgressWatcher levelController);
    }
}