//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.3
//     from Assets/Settings/GameInput.inputactions
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

namespace DinoGame.Input
{
    public partial class @GameInput: IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @GameInput()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameInput"",
    ""maps"": [
        {
            ""name"": ""Ui"",
            ""id"": ""974b91df-24d1-42c3-a188-b179f193d7a0"",
            ""actions"": [],
            ""bindings"": []
        },
        {
            ""name"": ""Player"",
            ""id"": ""0b450e22-3d6f-48f4-a026-28d47b8fac32"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""77bcb14f-d05f-4559-acba-e80b2897f082"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""15af3cca-ef33-47a3-86ab-98866a9bc81a"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""d3546d5b-7376-455d-9d4a-5eefaff7b66b"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""a5ac55f4-8d87-4efd-b8f9-02195928520c"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""1e778571-0374-4407-af33-a1324c73a6d3"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""74784510-f5c2-48be-85c2-936193b098ab"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""ab24de6d-9743-4cf6-a23d-1df75ad9896f"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Camera"",
            ""id"": ""592db438-b0c8-490f-8492-71364031757b"",
            ""actions"": [
                {
                    ""name"": ""Zoom"",
                    ""type"": ""Value"",
                    ""id"": ""f7b5c1eb-70ec-4627-9c6d-0469feea0764"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""bc543076-bf51-4f2a-a1fb-36ad0a23fd35"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""46b389af-349a-4ebf-8796-1887b705a0bd"",
                    ""path"": ""<Pointer>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e5e76682-f4c0-4972-b447-b35e161c37ed"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""51b956ba-2210-46e2-9369-ac04ef8b80c3"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Zoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Ui
            m_Ui = asset.FindActionMap("Ui", throwIfNotFound: true);
            // Player
            m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
            m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
            // Camera
            m_Camera = asset.FindActionMap("Camera", throwIfNotFound: true);
            m_Camera_Zoom = m_Camera.FindAction("Zoom", throwIfNotFound: true);
            m_Camera_Look = m_Camera.FindAction("Look", throwIfNotFound: true);
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

        // Ui
        private readonly InputActionMap m_Ui;
        private List<IUiActions> m_UiActionsCallbackInterfaces = new List<IUiActions>();
        public struct UiActions
        {
            private @GameInput m_Wrapper;
            public UiActions(@GameInput wrapper) { m_Wrapper = wrapper; }
            public InputActionMap Get() { return m_Wrapper.m_Ui; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(UiActions set) { return set.Get(); }
            public void AddCallbacks(IUiActions instance)
            {
                if (instance == null || m_Wrapper.m_UiActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_UiActionsCallbackInterfaces.Add(instance);
            }

            private void UnregisterCallbacks(IUiActions instance)
            {
            }

            public void RemoveCallbacks(IUiActions instance)
            {
                if (m_Wrapper.m_UiActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            public void SetCallbacks(IUiActions instance)
            {
                foreach (var item in m_Wrapper.m_UiActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_UiActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }
        public UiActions @Ui => new UiActions(this);

        // Player
        private readonly InputActionMap m_Player;
        private List<IPlayerActions> m_PlayerActionsCallbackInterfaces = new List<IPlayerActions>();
        private readonly InputAction m_Player_Move;
        public struct PlayerActions
        {
            private @GameInput m_Wrapper;
            public PlayerActions(@GameInput wrapper) { m_Wrapper = wrapper; }
            public InputAction @Move => m_Wrapper.m_Player_Move;
            public InputActionMap Get() { return m_Wrapper.m_Player; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
            public void AddCallbacks(IPlayerActions instance)
            {
                if (instance == null || m_Wrapper.m_PlayerActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_PlayerActionsCallbackInterfaces.Add(instance);
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
            }

            private void UnregisterCallbacks(IPlayerActions instance)
            {
                @Move.started -= instance.OnMove;
                @Move.performed -= instance.OnMove;
                @Move.canceled -= instance.OnMove;
            }

            public void RemoveCallbacks(IPlayerActions instance)
            {
                if (m_Wrapper.m_PlayerActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            public void SetCallbacks(IPlayerActions instance)
            {
                foreach (var item in m_Wrapper.m_PlayerActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_PlayerActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }
        public PlayerActions @Player => new PlayerActions(this);

        // Camera
        private readonly InputActionMap m_Camera;
        private List<ICameraActions> m_CameraActionsCallbackInterfaces = new List<ICameraActions>();
        private readonly InputAction m_Camera_Zoom;
        private readonly InputAction m_Camera_Look;
        public struct CameraActions
        {
            private @GameInput m_Wrapper;
            public CameraActions(@GameInput wrapper) { m_Wrapper = wrapper; }
            public InputAction @Zoom => m_Wrapper.m_Camera_Zoom;
            public InputAction @Look => m_Wrapper.m_Camera_Look;
            public InputActionMap Get() { return m_Wrapper.m_Camera; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(CameraActions set) { return set.Get(); }
            public void AddCallbacks(ICameraActions instance)
            {
                if (instance == null || m_Wrapper.m_CameraActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_CameraActionsCallbackInterfaces.Add(instance);
                @Zoom.started += instance.OnZoom;
                @Zoom.performed += instance.OnZoom;
                @Zoom.canceled += instance.OnZoom;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
            }

            private void UnregisterCallbacks(ICameraActions instance)
            {
                @Zoom.started -= instance.OnZoom;
                @Zoom.performed -= instance.OnZoom;
                @Zoom.canceled -= instance.OnZoom;
                @Look.started -= instance.OnLook;
                @Look.performed -= instance.OnLook;
                @Look.canceled -= instance.OnLook;
            }

            public void RemoveCallbacks(ICameraActions instance)
            {
                if (m_Wrapper.m_CameraActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            public void SetCallbacks(ICameraActions instance)
            {
                foreach (var item in m_Wrapper.m_CameraActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_CameraActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }
        public CameraActions @Camera => new CameraActions(this);
        public interface IUiActions
        {
        }
        public interface IPlayerActions
        {
            void OnMove(InputAction.CallbackContext context);
        }
        public interface ICameraActions
        {
            void OnZoom(InputAction.CallbackContext context);
            void OnLook(InputAction.CallbackContext context);
        }
    }
}
