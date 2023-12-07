using NicePlayTestTask.Gameplay.Logic;

namespace NicePlayTestTask.Services.LevelProgress
{
    public class LevelProgressService : ILevelProgressService
    {
        public LevelProgressWatcher LevelProgressWatcher { get; set; }

        public void InitForLevel(LevelProgressWatcher levelController)
        {
            LevelProgressWatcher = levelController;
        }
    }
}