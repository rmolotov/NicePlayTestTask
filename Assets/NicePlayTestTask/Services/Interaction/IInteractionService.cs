using System;
using Zenject;
using NicePlayTestTask.Gameplay.Ingredients;
using NicePlayTestTask.Gameplay.Ingredients.Components;

namespace NicePlayTestTask.Services.Interaction
{
    public interface IInteractionService: IInitializable, IDisposable
    {
        IngredientInteraction CurrentInteraction { get; }
    }
}