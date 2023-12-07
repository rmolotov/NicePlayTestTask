using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace NicePlayTestTask.Services.Input
{
    public class InputService : IInputService
    {
        private readonly PlayerControls _controls;
        
        public Action<Vector2> PointerPositionChanged { get; set; }
        
        public Action Drag { get; set; }
        public Action Drop { get; set; }

        public Action ReloadScene { get; set; }
        public Action LoadProgress { get; set; }
        public Action SaveProgress { get; set; }
        public Action ShowCombinations { get; set; }

        public InputService()
        {
            _controls = new PlayerControls();
            _controls.Enable();
            SubscribeControls(true);
        }

        ~InputService()
        {
            SubscribeControls(false);
            _controls.Disable();
        }

        private void SubscribeControls(bool value)
        {
            if (value)
            {
                _controls.Gameplay.Move.performed += OnPointerMove;
                _controls.Gameplay.Move.canceled  += OnPointerMove;

                _controls.Gameplay.Drag.performed += OnPointerPress;
                _controls.Gameplay.Drop.performed += OnPointerRelease;

                _controls.Hotkeys.ReloadScene.performed      += OnReloadScene;
                _controls.Hotkeys.SaveProgress.performed     += OnSaveProgress;
                _controls.Hotkeys.LoadProgress.performed     += OnLoadProgress;
                _controls.Hotkeys.ShowCombinations.performed += OnShowCombinations;

            }
            else
            {
                _controls.Gameplay.Move.performed -= OnPointerMove;
                _controls.Gameplay.Move.canceled  -= OnPointerMove;

                _controls.Gameplay.Drag.performed -= OnPointerPress;
                _controls.Gameplay.Drop.performed -= OnPointerRelease;
                
                _controls.Hotkeys.ReloadScene.performed      -= OnReloadScene;
                _controls.Hotkeys.SaveProgress.performed     -= OnSaveProgress;
                _controls.Hotkeys.LoadProgress.performed     -= OnLoadProgress;
                _controls.Hotkeys.ShowCombinations.performed -= OnShowCombinations;
            }
        }

        #region Adapter methods
        
        private void OnPointerMove(InputAction.CallbackContext ctx) => 
            PointerPositionChanged?.Invoke(ctx.ReadValue<Vector2>());

        private void OnPointerPress(InputAction.CallbackContext ctx) =>
            Drag?.Invoke();
        
        private void OnPointerRelease(InputAction.CallbackContext ctx) =>
            Drop?.Invoke();


        private void OnReloadScene(InputAction.CallbackContext ctx) =>
            ReloadScene?.Invoke();

        private void OnSaveProgress(InputAction.CallbackContext ctx) =>
            SaveProgress?.Invoke();
        
        private void OnLoadProgress(InputAction.CallbackContext ctx) =>
            LoadProgress?.Invoke();

        private void OnShowCombinations(InputAction.CallbackContext ctx) =>
            ShowCombinations?.Invoke();

        #endregion
    }
}