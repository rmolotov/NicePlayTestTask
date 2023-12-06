using System.Threading.Tasks;
using NicePlayTestTask.Meta.HUD;
using NicePlayTestTask.Meta.Menu;

namespace NicePlayTestTask.Infrastructure.Factorises.Interfaces
{
    public interface IUIFactory
    {
        HUDController HUDController { get; }
        
        Task WarmUp();
        void CleanUp();
        
        Task CreateUIRoot();
        Task<HUDController> CreateHud();
        Task<MenuController> CreateMainMenu();
    }
}