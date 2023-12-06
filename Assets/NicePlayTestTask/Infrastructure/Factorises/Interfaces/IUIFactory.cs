using System.Threading.Tasks;
using UnityEngine;
using NicePlayTestTask.Meta.HUD;
using NicePlayTestTask.Meta.Menu;

namespace NicePlayTestTask.Infrastructure.Factorises.Interfaces
{
    public interface IUIFactory
    {
        HUDController HUDController { get; }
        
        Task WarmUp();
        void CleanUp();
        
        Task<Canvas> CreateUIRoot();
        Task<HUDController> CreateHud();
        Task<MenuController> CreateMainMenu();
    }
}