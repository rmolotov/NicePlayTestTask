using System;
using UnityEngine;

namespace NicePlayTestTask.Gameplay.Logic
{
    [RequireComponent(typeof(Collider2D))]
    public class PointerObserver : MonoBehaviour
    {
        public event Action PointerEnter;
        public event Action PointerExit;

        // public void OnPointerEnter(PointerEventData eventData) => 
        //     PointerEnter?.Invoke(eventData);
        //
        // public void OnPointerExit(PointerEventData eventData) => 
        //     PointerExit?.Invoke(eventData);

        private void OnMouseEnter()
        {
            PointerEnter?.Invoke();
        }

        private void OnMouseExit()
        {
            PointerExit?.Invoke();
        }
    }
}