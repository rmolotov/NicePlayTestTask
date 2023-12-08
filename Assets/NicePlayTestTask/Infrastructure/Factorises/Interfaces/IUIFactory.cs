using System.Threading.Tasks;
using NicePlayTestTask.Meta.CombinationsList;
using UnityEngine;
using NicePlayTestTask.Meta.HUD;
using NicePlayTestTask.Meta.Menu;

namespace NicePlayTestTask.Infrastructure.Factorises.Interfaces
{
    public interface IUIFactory
    {
        Task WarmUp();
        void CleanUp();
        
        Task<Canvas> GetOrCreateUIRoot();
        Task<HUDController> GetOrCreateHud();
        
        Task<MenuController> CreateMainMenu();
        Task<CombinationsWindow> GetOrCreateCombinationsWindow();
    }
}