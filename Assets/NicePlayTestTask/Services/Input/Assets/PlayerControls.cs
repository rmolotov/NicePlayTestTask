//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/NicePlayTestTask/Services/Input/Assets/PlayerControls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace NicePlayTestTask.Services.Input
{
    public partial class @PlayerControls: IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @PlayerControls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""cfdf63f8-1c6f-47d6-98cd-48f1fb650623"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""de99bec8-dfc1-4016-ba5f-9a7aae508873"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Drag"",
                    ""type"": ""Button"",
                    ""id"": ""38561400-eb1a-4ef4-a3f1-77bac069499e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Drop"",
                    ""type"": ""Button"",
                    ""id"": ""c33c0754-2c3e-4021-8e7d-ed7fd7cd580f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f3b33b31-7e7d-4d34-96ad-637fe56cee8f"",
                    ""path"": ""<Pointer>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""17a629d2-914a-4845-ab43-8a8defd739bb"",
                    ""path"": ""<Pointer>/press"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Drag"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5a8ca4a4-0ff0-48fc-bf97-131fd9147481"",
                    ""path"": ""<Pointer>/press"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Drop"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Hotkeys"",
            ""id"": ""79877735-2a52-412a-81ef-08710c494609"",
            ""actions"": [
                {
                    ""name"": ""ReloadScene"",
                    ""type"": ""Button"",
                    ""id"": ""51263c92-fcda-499b-a146-4adff4fbbfba"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""SaveProgress"",
                    ""type"": ""Button"",
                    ""id"": ""08cf6d96-ada9-4d49-bf3a-31014b1bb846"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""LoadProgress"",
                    ""type"": ""Button"",
                    ""id"": ""0c26b699-6b94-4642-9ed5-8abdb3f1a248"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""ShowCombinations"",
                    ""type"": ""Button"",
                    ""id"": ""43394b26-e0f3-4222-9b8c-29647f6106a9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""ReturnToMenu"",
                    ""type"": ""Button"",
                    ""id"": ""ca6dc784-fe50-40e9-a88a-d8b74eb9d3d1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b9b14ee0-70c0-41fb-a137-60eed892f1c1"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ReloadScene"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""10d3af76-1205-4dc2-a901-07a735cbf017"",
                    ""path"": ""<Keyboard>/l"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LoadProgress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2f15aedb-1ef2-4c6d-96d6-a34f58b05288"",
                    ""path"": ""<Keyboard>/t"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShowCombinations"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dec56899-e023-4065-89d3-6095464cd3f8"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SaveProgress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""80d77ebf-b1c9-4529-919b-3d5839e4a782"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ReturnToMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Gameplay
            m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
            m_Gameplay_Move = m_Gameplay.FindAction("Move", throwIfNotFound: true);
            m_Gameplay_Drag = m_Gameplay.FindAction("Drag", throwIfNotFound: true);
            m_Gameplay_Drop = m_Gameplay.FindAction("Drop", throwIfNotFound: true);
            // Hotkeys
            m_Hotkeys = asset.FindActionMap("Hotkeys", throwIfNotFound: true);
            m_Hotkeys_ReloadScene = m_Hotkeys.FindAction("ReloadScene", throwIfNotFound: true);
            m_Hotkeys_SaveProgress = m_Hotkeys.FindAction("SaveProgress", throwIfNotFound: true);
            m_Hotkeys_LoadProgress = m_Hotkeys.FindAction("LoadProgress", throwIfNotFound: true);
            m_Hotkeys_ShowCombinations = m_Hotkeys.FindAction("ShowCombinations", throwIfNotFound: true);
            m_Hotkeys_ReturnToMenu = m_Hotkeys.FindAction("ReturnToMenu", throwIfNotFound: true);
        }

        public void Dispose()
        {
            UnityEngine.Object.Destroy(asset);
        }

        public InputBinding? bindingMask
        {
            get => asset.bindingMask;
            set => asset.bindingMask = value;
        }

        public ReadOnlyArray<InputDevice>? devices
        {
            get => asset.devices;
            set => asset.devices = value;
        }

        public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

        public bool Contains(InputAction action)
        {
            return asset.Contains(action);
        }

        public IEnumerator<InputAction> GetEnumerator()
        {
            return asset.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Enable()
        {
            asset.Enable();
        }

        public void Disable()
        {
            asset.Disable();
        }

        public IEnumerable<InputBinding> bindings => asset.bindings;

        public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
        {
            return asset.FindAction(actionNameOrId, throwIfNotFound);
        }

        public int FindBinding(InputBinding bindingMask, out InputAction action)
        {
            return asset.FindBinding(bindingMask, out action);
        }

        // Gameplay
        private readonly InputActionMap m_Gameplay;
        private List<IGameplayActions> m_GameplayActionsCallbackInterfaces = new List<IGameplayActions>();
        private readonly InputAction m_Gameplay_Move;
        private readonly InputAction m_Gameplay_Drag;
        private readonly InputAction m_Gameplay_Drop;
        public struct GameplayActions
        {
            private @PlayerControls m_Wrapper;
            public GameplayActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Move => m_Wrapper.m_Gameplay_Move;
            public InputAction @Drag => m_Wrapper.m_Gameplay_Drag;
            public InputAction @Drop => m_Wrapper.m_Gameplay_Drop;
            public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
            public void AddCallbacks(IGameplayActions instance)
            {
                if (instance == null || m_Wrapper.m_GameplayActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_GameplayActionsCallbackInterfaces.Add(instance);
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Drag.started += instance.OnDrag;
                @Drag.performed += instance.OnDrag;
                @Drag.canceled += instance.OnDrag;
                @Drop.started += instance.OnDrop;
                @Drop.performed += instance.OnDrop;
                @Drop.canceled += instance.OnDrop;
            }

            private void UnregisterCallbacks(IGameplayActions instance)
            {
                @Move.started -= instance.OnMove;
                @Move.performed -= instance.OnMove;
                @Move.canceled -= instance.OnMove;
                @Drag.started -= instance.OnDrag;
                @Drag.performed -= instance.OnDrag;
                @Drag.canceled -= instance.OnDrag;
                @Drop.started -= instance.OnDrop;
                @Drop.performed -= instance.OnDrop;
                @Drop.canceled -= instance.OnDrop;
            }

            public void RemoveCallbacks(IGameplayActions instance)
            {
                if (m_Wrapper.m_GameplayActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            public void SetCallbacks(IGameplayActions instance)
            {
                foreach (var item in m_Wrapper.m_GameplayActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_GameplayActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }
        public GameplayActions @Gameplay => new GameplayActions(this);

        // Hotkeys
        private readonly InputActionMap m_Hotkeys;
        private List<IHotkeysActions> m_HotkeysActionsCallbackInterfaces = new List<IHotkeysActions>();
        private readonly InputAction m_Hotkeys_ReloadScene;
        private readonly InputAction m_Hotkeys_SaveProgress;
        private readonly InputAction m_Hotkeys_LoadProgress;
        private readonly InputAction m_Hotkeys_ShowCombinations;
        private readonly InputAction m_Hotkeys_ReturnToMenu;
        public struct HotkeysActions
        {
            private @PlayerControls m_Wrapper;
            public HotkeysActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @ReloadScene => m_Wrapper.m_Hotkeys_ReloadScene;
            public InputAction @SaveProgress => m_Wrapper.m_Hotkeys_SaveProgress;
            public InputAction @LoadProgress => m_Wrapper.m_Hotkeys_LoadProgress;
            public InputAction @ShowCombinations => m_Wrapper.m_Hotkeys_ShowCombinations;
            public InputAction @ReturnToMenu => m_Wrapper.m_Hotkeys_ReturnToMenu;
            public InputActionMap Get() { return m_Wrapper.m_Hotkeys; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(HotkeysActions set) { return set.Get(); }
            public void AddCallbacks(IHotkeysActions instance)
            {
                if (instance == null || m_Wrapper.m_HotkeysActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_HotkeysActionsCallbackInterfaces.Add(instance);
                @ReloadScene.started += instance.OnReloadScene;
                @ReloadScene.performed += instance.OnReloadScene;
                @ReloadScene.canceled += instance.OnReloadScene;
                @SaveProgress.started += instance.OnSaveProgress;
                @SaveProgress.performed += instance.OnSaveProgress;
                @SaveProgress.canceled += instance.OnSaveProgress;
                @LoadProgress.started += instance.OnLoadProgress;
                @LoadProgress.performed += instance.OnLoadProgress;
                @LoadProgress.canceled += instance.OnLoadProgress;
                @ShowCombinations.started += instance.OnShowCombinations;
                @ShowCombinations.performed += instance.OnShowCombinations;
                @ShowCombinations.canceled += instance.OnShowCombinations;
                @ReturnToMenu.started += instance.OnReturnToMenu;
                @ReturnToMenu.performed += instance.OnReturnToMenu;
                @ReturnToMenu.canceled += instance.OnReturnToMenu;
            }

            private void UnregisterCallbacks(IHotkeysActions instance)
            {
                @ReloadScene.started -= instance.OnReloadScene;
                @ReloadScene.performed -= instance.OnReloadScene;
                @ReloadScene.canceled -= instance.OnReloadScene;
                @SaveProgress.started -= instance.OnSaveProgress;
                @SaveProgress.performed -= instance.OnSaveProgress;
                @SaveProgress.canceled -= instance.OnSaveProgress;
                @LoadProgress.started -= instance.OnLoadProgress;
                @LoadProgress.performed -= instance.OnLoadProgress;
                @LoadProgress.canceled -= instance.OnLoadProgress;
                @ShowCombinations.started -= instance.OnShowCombinations;
                @ShowCombinations.performed -= instance.OnShowCombinations;
                @ShowCombinations.canceled -= instance.OnShowCombinations;
                @ReturnToMenu.started -= instance.OnReturnToMenu;
                @ReturnToMenu.performed -= instance.OnReturnToMenu;
                @ReturnToMenu.canceled -= instance.OnReturnToMenu;
            }

            public void RemoveCallbacks(IHotkeysActions instance)
            {
                if (m_Wrapper.m_HotkeysActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            public void SetCallbacks(IHotkeysActions instance)
            {
                foreach (var item in m_Wrapper.m_HotkeysActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_HotkeysActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }
        public HotkeysActions @Hotkeys => new HotkeysActions(this);
        public interface IGameplayActions
        {
            void OnMove(InputAction.CallbackContext context);
            void OnDrag(InputAction.CallbackContext context);
            void OnDrop(InputAction.CallbackContext context);
        }
        public interface IHotkeysActions
        {
            void OnReloadScene(InputAction.CallbackContext context);
            void OnSaveProgress(InputAction.CallbackContext context);
            void OnLoadProgress(InputAction.CallbackContext context);
            void OnShowCombinations(InputAction.CallbackContext context);
            void OnReturnToMenu(InputAction.CallbackContext context);
        }
    }
}
