using System;
using Zenject;
using NicePlayTestTask.Gameplay.Ingredients;

namespace NicePlayTestTask.Services.Interaction
{
    public interface IInteractionService: IInitializable, IDisposable
    {
        IngredientInteraction CurrentInteraction { get; }
    }
}