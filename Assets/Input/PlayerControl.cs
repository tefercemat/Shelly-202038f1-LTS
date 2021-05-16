// GENERATED AUTOMATICALLY FROM 'Assets/Input/PlayerControl.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControl : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControl()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControl"",
    ""maps"": [
        {
            ""name"": ""Movement"",
            ""id"": ""5de45c7b-0c50-4954-b110-04dc5a4225be"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""b1e47fde-013e-4f2a-89a2-dcd98b62d224"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""83657c10-563f-4a14-920e-a4bfd8f7fecc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack2"",
                    ""type"": ""Button"",
                    ""id"": ""936f7459-f7a4-4f7d-9e75-a5e3b331f52c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""b1ebf65b-4387-4b9a-92a3-a19f16b18141"",
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
                    ""id"": ""7db445a7-036b-4def-8292-e4aa9cfaef4b"",
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
                    ""id"": ""2c3b3847-3e4c-45fe-a6c9-b8b2ef2e1e28"",
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
                    ""id"": ""a4f82868-cb5d-4b52-84b3-4d359b5e47f3"",
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
                    ""id"": ""7af85e39-6343-4a2c-896a-1bd41f3f5eb8"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""GamPadLeftStick"",
                    ""id"": ""40c8f308-2942-40e3-b958-07a7e38e3581"",
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
                    ""id"": ""c07cdda0-711d-428f-b71a-6defa5c59386"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""8f634bdb-1dbf-4eaf-b414-11e7d1df01b3"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""20170b36-a66f-44a3-be7a-711326ddb91b"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""6a7c7c3b-331f-4cc5-8905-9c357c2721a7"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""5a5bd9d9-fc76-46ec-bf44-b6d9b09d71e1"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a0588910-9847-49e0-8d46-105741a7a07f"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e36b0286-daef-49be-999b-b662b8b13424"",
                    ""path"": ""<Keyboard>/comma"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""InGameMenu"",
            ""id"": ""2651b9c5-e776-41e9-8132-f842c36490c7"",
            ""actions"": [
                {
                    ""name"": ""ShowMenu"",
                    ""type"": ""Button"",
                    ""id"": ""18fccc0b-4b1a-45ed-87c7-b3bd968c9db5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""5992506f-18a4-4979-939e-6a38bf8d456b"",
                    ""path"": ""<Keyboard>/m"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShowMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Movement
        m_Movement = asset.FindActionMap("Movement", throwIfNotFound: true);
        m_Movement_Move = m_Movement.FindAction("Move", throwIfNotFound: true);
        m_Movement_Attack = m_Movement.FindAction("Attack", throwIfNotFound: true);
        m_Movement_Attack2 = m_Movement.FindAction("Attack2", throwIfNotFound: true);
        // InGameMenu
        m_InGameMenu = asset.FindActionMap("InGameMenu", throwIfNotFound: true);
        m_InGameMenu_ShowMenu = m_InGameMenu.FindAction("ShowMenu", throwIfNotFound: true);
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

    // Movement
    private readonly InputActionMap m_Movement;
    private IMovementActions m_MovementActionsCallbackInterface;
    private readonly InputAction m_Movement_Move;
    private readonly InputAction m_Movement_Attack;
    private readonly InputAction m_Movement_Attack2;
    public struct MovementActions
    {
        private @PlayerControl m_Wrapper;
        public MovementActions(@PlayerControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Movement_Move;
        public InputAction @Attack => m_Wrapper.m_Movement_Attack;
        public InputAction @Attack2 => m_Wrapper.m_Movement_Attack2;
        public InputActionMap Get() { return m_Wrapper.m_Movement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovementActions set) { return set.Get(); }
        public void SetCallbacks(IMovementActions instance)
        {
            if (m_Wrapper.m_MovementActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnMove;
                @Attack.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnAttack;
                @Attack2.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnAttack2;
                @Attack2.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnAttack2;
                @Attack2.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnAttack2;
            }
            m_Wrapper.m_MovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @Attack2.started += instance.OnAttack2;
                @Attack2.performed += instance.OnAttack2;
                @Attack2.canceled += instance.OnAttack2;
            }
        }
    }
    public MovementActions @Movement => new MovementActions(this);

    // InGameMenu
    private readonly InputActionMap m_InGameMenu;
    private IInGameMenuActions m_InGameMenuActionsCallbackInterface;
    private readonly InputAction m_InGameMenu_ShowMenu;
    public struct InGameMenuActions
    {
        private @PlayerControl m_Wrapper;
        public InGameMenuActions(@PlayerControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @ShowMenu => m_Wrapper.m_InGameMenu_ShowMenu;
        public InputActionMap Get() { return m_Wrapper.m_InGameMenu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InGameMenuActions set) { return set.Get(); }
        public void SetCallbacks(IInGameMenuActions instance)
        {
            if (m_Wrapper.m_InGameMenuActionsCallbackInterface != null)
            {
                @ShowMenu.started -= m_Wrapper.m_InGameMenuActionsCallbackInterface.OnShowMenu;
                @ShowMenu.performed -= m_Wrapper.m_InGameMenuActionsCallbackInterface.OnShowMenu;
                @ShowMenu.canceled -= m_Wrapper.m_InGameMenuActionsCallbackInterface.OnShowMenu;
            }
            m_Wrapper.m_InGameMenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ShowMenu.started += instance.OnShowMenu;
                @ShowMenu.performed += instance.OnShowMenu;
                @ShowMenu.canceled += instance.OnShowMenu;
            }
        }
    }
    public InGameMenuActions @InGameMenu => new InGameMenuActions(this);
    public interface IMovementActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnAttack2(InputAction.CallbackContext context);
    }
    public interface IInGameMenuActions
    {
        void OnShowMenu(InputAction.CallbackContext context);
    }
}
