//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Input/Controls.inputactions
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

namespace Management
{
    public partial class @Controls : IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @Controls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Default"",
            ""id"": ""d104098f-5de8-46d3-9fe9-d15463eacdeb"",
            ""actions"": [
                {
                    ""name"": ""VerticalAxis"",
                    ""type"": ""Value"",
                    ""id"": ""8379bbfb-e567-4605-8044-93df9ed49f7a"",
                    ""expectedControlType"": ""Double"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""HorizontalAxis"",
                    ""type"": ""Value"",
                    ""id"": ""87cf8331-e78e-4356-9333-8e3b943c3c9b"",
                    ""expectedControlType"": ""Double"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""Value"",
                    ""id"": ""36dc2073-7f7c-46e1-b01c-b62c0ffe6fee"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""PrimaryFire"",
                    ""type"": ""Button"",
                    ""id"": ""7b625cb7-a8fe-4ba8-bf11-f0a047f69411"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SecondaryFire"",
                    ""type"": ""Button"",
                    ""id"": ""1cc2bbcd-fa0f-4a32-9662-4173e3a2b4d7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Shift"",
                    ""type"": ""Button"",
                    ""id"": ""9de8f6da-43c6-4b09-aa82-10b789b9f919"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""CapsLock"",
                    ""type"": ""Button"",
                    ""id"": ""1ddd413f-aec2-49f8-ab50-dc3767ecbeba"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""2a549aca-8580-467f-8491-ce513d884b02"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""VerticalAxis"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""bb6e6daf-3a8f-4ab7-a21b-0b7f06f3fedd"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""VerticalAxis"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""b3e17a94-a8ab-40f3-9551-0533a51f8270"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""VerticalAxis"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""cbbf4a4b-b3e6-417d-9280-aa84908d51f8"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorizontalAxis"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""220ac975-1005-471b-b396-98594e725588"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorizontalAxis"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""f024c720-3d13-43be-8197-a1d3e97965c6"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorizontalAxis"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""2962e7e4-ed2a-4b97-8708-7d310fece54b"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""52a006db-0dbe-4451-ad68-4ed5957b4014"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrimaryFire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fce337be-eee9-441c-b092-1ddbb22335ad"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SecondaryFire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b1b00de6-0164-46f6-8769-0fabe75d5639"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shift"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7ab2dc37-26e3-455e-8f2f-7e45f35fa727"",
                    ""path"": ""<Keyboard>/rightShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shift"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8dfc9dc8-dbe7-4d5d-b593-a6b2c22756b4"",
                    ""path"": ""<Keyboard>/capsLock"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CapsLock"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Default
            m_Default = asset.FindActionMap("Default", throwIfNotFound: true);
            m_Default_VerticalAxis = m_Default.FindAction("VerticalAxis", throwIfNotFound: true);
            m_Default_HorizontalAxis = m_Default.FindAction("HorizontalAxis", throwIfNotFound: true);
            m_Default_MousePosition = m_Default.FindAction("MousePosition", throwIfNotFound: true);
            m_Default_PrimaryFire = m_Default.FindAction("PrimaryFire", throwIfNotFound: true);
            m_Default_SecondaryFire = m_Default.FindAction("SecondaryFire", throwIfNotFound: true);
            m_Default_Shift = m_Default.FindAction("Shift", throwIfNotFound: true);
            m_Default_CapsLock = m_Default.FindAction("CapsLock", throwIfNotFound: true);
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

        // Default
        private readonly InputActionMap m_Default;
        private IDefaultActions m_DefaultActionsCallbackInterface;
        private readonly InputAction m_Default_VerticalAxis;
        private readonly InputAction m_Default_HorizontalAxis;
        private readonly InputAction m_Default_MousePosition;
        private readonly InputAction m_Default_PrimaryFire;
        private readonly InputAction m_Default_SecondaryFire;
        private readonly InputAction m_Default_Shift;
        private readonly InputAction m_Default_CapsLock;
        public struct DefaultActions
        {
            private @Controls m_Wrapper;
            public DefaultActions(@Controls wrapper) { m_Wrapper = wrapper; }
            public InputAction @VerticalAxis => m_Wrapper.m_Default_VerticalAxis;
            public InputAction @HorizontalAxis => m_Wrapper.m_Default_HorizontalAxis;
            public InputAction @MousePosition => m_Wrapper.m_Default_MousePosition;
            public InputAction @PrimaryFire => m_Wrapper.m_Default_PrimaryFire;
            public InputAction @SecondaryFire => m_Wrapper.m_Default_SecondaryFire;
            public InputAction @Shift => m_Wrapper.m_Default_Shift;
            public InputAction @CapsLock => m_Wrapper.m_Default_CapsLock;
            public InputActionMap Get() { return m_Wrapper.m_Default; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(DefaultActions set) { return set.Get(); }
            public void SetCallbacks(IDefaultActions instance)
            {
                if (m_Wrapper.m_DefaultActionsCallbackInterface != null)
                {
                    @VerticalAxis.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnVerticalAxis;
                    @VerticalAxis.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnVerticalAxis;
                    @VerticalAxis.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnVerticalAxis;
                    @HorizontalAxis.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnHorizontalAxis;
                    @HorizontalAxis.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnHorizontalAxis;
                    @HorizontalAxis.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnHorizontalAxis;
                    @MousePosition.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnMousePosition;
                    @MousePosition.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnMousePosition;
                    @MousePosition.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnMousePosition;
                    @PrimaryFire.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnPrimaryFire;
                    @PrimaryFire.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnPrimaryFire;
                    @PrimaryFire.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnPrimaryFire;
                    @SecondaryFire.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnSecondaryFire;
                    @SecondaryFire.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnSecondaryFire;
                    @SecondaryFire.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnSecondaryFire;
                    @Shift.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnShift;
                    @Shift.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnShift;
                    @Shift.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnShift;
                    @CapsLock.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnCapsLock;
                    @CapsLock.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnCapsLock;
                    @CapsLock.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnCapsLock;
                }
                m_Wrapper.m_DefaultActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @VerticalAxis.started += instance.OnVerticalAxis;
                    @VerticalAxis.performed += instance.OnVerticalAxis;
                    @VerticalAxis.canceled += instance.OnVerticalAxis;
                    @HorizontalAxis.started += instance.OnHorizontalAxis;
                    @HorizontalAxis.performed += instance.OnHorizontalAxis;
                    @HorizontalAxis.canceled += instance.OnHorizontalAxis;
                    @MousePosition.started += instance.OnMousePosition;
                    @MousePosition.performed += instance.OnMousePosition;
                    @MousePosition.canceled += instance.OnMousePosition;
                    @PrimaryFire.started += instance.OnPrimaryFire;
                    @PrimaryFire.performed += instance.OnPrimaryFire;
                    @PrimaryFire.canceled += instance.OnPrimaryFire;
                    @SecondaryFire.started += instance.OnSecondaryFire;
                    @SecondaryFire.performed += instance.OnSecondaryFire;
                    @SecondaryFire.canceled += instance.OnSecondaryFire;
                    @Shift.started += instance.OnShift;
                    @Shift.performed += instance.OnShift;
                    @Shift.canceled += instance.OnShift;
                    @CapsLock.started += instance.OnCapsLock;
                    @CapsLock.performed += instance.OnCapsLock;
                    @CapsLock.canceled += instance.OnCapsLock;
                }
            }
        }
        public DefaultActions @Default => new DefaultActions(this);
        public interface IDefaultActions
        {
            void OnVerticalAxis(InputAction.CallbackContext context);
            void OnHorizontalAxis(InputAction.CallbackContext context);
            void OnMousePosition(InputAction.CallbackContext context);
            void OnPrimaryFire(InputAction.CallbackContext context);
            void OnSecondaryFire(InputAction.CallbackContext context);
            void OnShift(InputAction.CallbackContext context);
            void OnCapsLock(InputAction.CallbackContext context);
        }
    }
}
