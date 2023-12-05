using System;
using UnityEngine;

namespace NicePlayTestTask.Gameplay.Logic
{
    [RequireComponent(typeof(Collider2D))]
    public class PointerObserver : MonoBehaviour
    {
        public event Action PointerEnter;
        public event Action PointerExit;

        private void OnMouseEnter() => 
            PointerEnter?.Invoke();

        private void OnMouseExit() => 
            PointerExit?.Invoke();
    }
}