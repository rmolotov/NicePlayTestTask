using UnityEngine;
using NicePlayTestTask.Gameplay.Logic;

namespace NicePlayTestTask.Gameplay.Ingredients
{
    public class IngredientInteractionRange : MonoBehaviour
    {
        [SerializeField] private PointerObserver pointerObserver;
        [SerializeField] private IngredientPointerFollow followComponent;
        
        private void Start()
        {
            pointerObserver.PointerEnter += BeginInteraction;
            pointerObserver.PointerExit += EndInteraction;
        }

        private void OnDestroy()
        {
            pointerObserver.PointerEnter -= BeginInteraction;
            pointerObserver.PointerExit -= EndInteraction;
        }

        private void BeginInteraction()
        {
            print($"BeginInteraction {gameObject.name}");
        }

        private void EndInteraction()
        {
            print($"EndInteraction {gameObject.name}");
        }
    }
}