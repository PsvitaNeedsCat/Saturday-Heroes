// GENERATED AUTOMATICALLY FROM 'Assets/Input/MasterControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @MasterControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @MasterControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MasterControls"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""264ebfac-65c6-46df-9057-588d4a5153b3"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""0337b2f3-371c-4399-b35a-68ef5e13fd35"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""938e362b-6eea-48fd-a0bc-060ead04d0d7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Revive"",
                    ""type"": ""Button"",
                    ""id"": ""974c1635-890b-438c-a7ce-60e8d3297c55"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold(duration=0.2)""
                },
                {
                    ""name"": ""Card Selection"",
                    ""type"": ""Button"",
                    ""id"": ""269b735c-076e-453e-b484-58895ca42a02"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold(duration=0.2)""
                },
                {
                    ""name"": ""Play Card"",
                    ""type"": ""Button"",
                    ""id"": ""ce281ee4-c274-4cd9-ab61-9875fa19a166"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold(duration=0.2)""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2fb15d35-5a80-4232-804d-65310a962ad6"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0bbc38c0-c37c-4d11-a6ad-03b91f76f357"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bce523ed-d2b6-4b6b-b28f-26de9a006065"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Revive"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""c3d249b9-a934-4fd2-a4cd-454386729233"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Card Selection"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""06e4b0e6-c58d-4894-ad25-98d1618dbb7a"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Card Selection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""b7ddab94-eef5-4418-bc53-08c967789810"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Card Selection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""6724961f-f21b-4cde-bd9f-456fe8acf9b2"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Play Card"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Movement = m_Player.FindAction("Movement", throwIfNotFound: true);
        m_Player_Attack = m_Player.FindAction("Attack", throwIfNotFound: true);
        m_Player_Revive = m_Player.FindAction("Revive", throwIfNotFound: true);
        m_Player_CardSelection = m_Player.FindAction("Card Selection", throwIfNotFound: true);
        m_Player_PlayCard = m_Player.FindAction("Play Card", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Movement;
    private readonly InputAction m_Player_Attack;
    private readonly InputAction m_Player_Revive;
    private readonly InputAction m_Player_CardSelection;
    private readonly InputAction m_Player_PlayCard;
    public struct PlayerActions
    {
        private @MasterControls m_Wrapper;
        public PlayerActions(@MasterControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Player_Movement;
        public InputAction @Attack => m_Wrapper.m_Player_Attack;
        public InputAction @Revive => m_Wrapper.m_Player_Revive;
        public InputAction @CardSelection => m_Wrapper.m_Player_CardSelection;
        public InputAction @PlayCard => m_Wrapper.m_Player_PlayCard;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Attack.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack;
                @Revive.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRevive;
                @Revive.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRevive;
                @Revive.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRevive;
                @CardSelection.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCardSelection;
                @CardSelection.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCardSelection;
                @CardSelection.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCardSelection;
                @PlayCard.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPlayCard;
                @PlayCard.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPlayCard;
                @PlayCard.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPlayCard;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @Revive.started += instance.OnRevive;
                @Revive.performed += instance.OnRevive;
                @Revive.canceled += instance.OnRevive;
                @CardSelection.started += instance.OnCardSelection;
                @CardSelection.performed += instance.OnCardSelection;
                @CardSelection.canceled += instance.OnCardSelection;
                @PlayCard.started += instance.OnPlayCard;
                @PlayCard.performed += instance.OnPlayCard;
                @PlayCard.canceled += instance.OnPlayCard;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnRevive(InputAction.CallbackContext context);
        void OnCardSelection(InputAction.CallbackContext context);
        void OnPlayCard(InputAction.CallbackContext context);
    }
}
