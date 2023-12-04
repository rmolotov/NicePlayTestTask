using System.Threading.Tasks;
using UnityEngine;

namespace NicePlayTestTask.Infrastructure.Factorises.Interfaces
{
    public interface IIngredientFactory
    {
        Task WarmUp();
        void CleanUp();
        
        Task<GameObject> Create(string key, Vector2 at);
    }
}