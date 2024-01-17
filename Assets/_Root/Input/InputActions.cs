//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.5.1
//     from Assets/_Root/Input/InputActions.inputactions
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

public partial class @InputActions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""cd9eef3e-c418-499e-b13e-2352b820604c"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""8f286cca-815f-4cba-9ebe-0975147d1bd5"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Value"",
                    ""id"": ""f0e5789d-0802-4ca5-839b-fdddcf4bd3d7"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WS"",
                    ""id"": ""49249f48-b4b4-43e9-99fe-214a73a120fd"",
                    ""path"": ""Dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""a314597f-31c0-47ac-aea7-8433695b5f99"",
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
                    ""id"": ""3a55aa53-ea2e-4c70-9e16-af313db7e91d"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""560b21ea-162d-4ae3-9028-a434486eef61"",
                    ""path"": ""<XRController>{LeftHand}/joystick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""AD"",
                    ""id"": ""020f9ea6-afcb-4cc8-8649-ed0593856d9c"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""left"",
                    ""id"": ""44d7c296-475f-43a1-a6e0-034d3754d022"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""44b47baa-a8f8-4342-a9c8-e7070fc32bd9"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""da6c4ebb-3712-4077-9a55-49f693db01e5"",
                    ""path"": ""<XRController>{RightHand}/joystick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Selector"",
            ""id"": ""b56f9730-6a2a-4954-b5e9-6498a40fa88f"",
            ""actions"": [
                {
                    ""name"": ""SelectServerVisibleAndInput"",
                    ""type"": ""Button"",
                    ""id"": ""b33a5cbc-7988-4c25-8a80-2b397523a6ae"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SelectClient0VisibleAndInput"",
                    ""type"": ""Button"",
                    ""id"": ""9b149287-1bb4-4e45-9cfc-25c1452b9e3d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SelectClient1VisibleAndInput"",
                    ""type"": ""Button"",
                    ""id"": ""fa9768b4-048a-4891-b430-23afd8ce334e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SelectClient0Input"",
                    ""type"": ""Button"",
                    ""id"": ""e603e248-e63f-483e-8176-a754c8203c2b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SelectClient1Input"",
                    ""type"": ""Button"",
                    ""id"": ""3660fcb6-d131-453b-bc62-469282d4847f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""1bb5787b-55bc-429a-b864-1c836bf24104"",
                    ""path"": ""<Keyboard>/backquote"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectServerVisibleAndInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a3783c21-d9cf-496b-826e-5e165587317f"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectClient0VisibleAndInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""25aba818-1899-48ab-96ac-623b198c85d4"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectClient1VisibleAndInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""03636cd0-ed1a-43e8-8a5f-c30adb13c982"",
                    ""path"": ""<Keyboard>/numpad1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectClient0Input"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cdae58f6-ca92-4812-af95-fd6c01d8f680"",
                    ""path"": ""<Keyboard>/numpad2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectClient1Input"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
        m_Player_Rotate = m_Player.FindAction("Rotate", throwIfNotFound: true);
        // Selector
        m_Selector = asset.FindActionMap("Selector", throwIfNotFound: true);
        m_Selector_SelectServerVisibleAndInput = m_Selector.FindAction("SelectServerVisibleAndInput", throwIfNotFound: true);
        m_Selector_SelectClient0VisibleAndInput = m_Selector.FindAction("SelectClient0VisibleAndInput", throwIfNotFound: true);
        m_Selector_SelectClient1VisibleAndInput = m_Selector.FindAction("SelectClient1VisibleAndInput", throwIfNotFound: true);
        m_Selector_SelectClient0Input = m_Selector.FindAction("SelectClient0Input", throwIfNotFound: true);
        m_Selector_SelectClient1Input = m_Selector.FindAction("SelectClient1Input", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private List<IPlayerActions> m_PlayerActionsCallbackInterfaces = new List<IPlayerActions>();
    private readonly InputAction m_Player_Move;
    private readonly InputAction m_Player_Rotate;
    public struct PlayerActions
    {
        private @InputActions m_Wrapper;
        public PlayerActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player_Move;
        public InputAction @Rotate => m_Wrapper.m_Player_Rotate;
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
            @Rotate.started += instance.OnRotate;
            @Rotate.performed += instance.OnRotate;
            @Rotate.canceled += instance.OnRotate;
        }

        private void UnregisterCallbacks(IPlayerActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @Rotate.started -= instance.OnRotate;
            @Rotate.performed -= instance.OnRotate;
            @Rotate.canceled -= instance.OnRotate;
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

    // Selector
    private readonly InputActionMap m_Selector;
    private List<ISelectorActions> m_SelectorActionsCallbackInterfaces = new List<ISelectorActions>();
    private readonly InputAction m_Selector_SelectServerVisibleAndInput;
    private readonly InputAction m_Selector_SelectClient0VisibleAndInput;
    private readonly InputAction m_Selector_SelectClient1VisibleAndInput;
    private readonly InputAction m_Selector_SelectClient0Input;
    private readonly InputAction m_Selector_SelectClient1Input;
    public struct SelectorActions
    {
        private @InputActions m_Wrapper;
        public SelectorActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @SelectServerVisibleAndInput => m_Wrapper.m_Selector_SelectServerVisibleAndInput;
        public InputAction @SelectClient0VisibleAndInput => m_Wrapper.m_Selector_SelectClient0VisibleAndInput;
        public InputAction @SelectClient1VisibleAndInput => m_Wrapper.m_Selector_SelectClient1VisibleAndInput;
        public InputAction @SelectClient0Input => m_Wrapper.m_Selector_SelectClient0Input;
        public InputAction @SelectClient1Input => m_Wrapper.m_Selector_SelectClient1Input;
        public InputActionMap Get() { return m_Wrapper.m_Selector; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SelectorActions set) { return set.Get(); }
        public void AddCallbacks(ISelectorActions instance)
        {
            if (instance == null || m_Wrapper.m_SelectorActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_SelectorActionsCallbackInterfaces.Add(instance);
            @SelectServerVisibleAndInput.started += instance.OnSelectServerVisibleAndInput;
            @SelectServerVisibleAndInput.performed += instance.OnSelectServerVisibleAndInput;
            @SelectServerVisibleAndInput.canceled += instance.OnSelectServerVisibleAndInput;
            @SelectClient0VisibleAndInput.started += instance.OnSelectClient0VisibleAndInput;
            @SelectClient0VisibleAndInput.performed += instance.OnSelectClient0VisibleAndInput;
            @SelectClient0VisibleAndInput.canceled += instance.OnSelectClient0VisibleAndInput;
            @SelectClient1VisibleAndInput.started += instance.OnSelectClient1VisibleAndInput;
            @SelectClient1VisibleAndInput.performed += instance.OnSelectClient1VisibleAndInput;
            @SelectClient1VisibleAndInput.canceled += instance.OnSelectClient1VisibleAndInput;
            @SelectClient0Input.started += instance.OnSelectClient0Input;
            @SelectClient0Input.performed += instance.OnSelectClient0Input;
            @SelectClient0Input.canceled += instance.OnSelectClient0Input;
            @SelectClient1Input.started += instance.OnSelectClient1Input;
            @SelectClient1Input.performed += instance.OnSelectClient1Input;
            @SelectClient1Input.canceled += instance.OnSelectClient1Input;
        }

        private void UnregisterCallbacks(ISelectorActions instance)
        {
            @SelectServerVisibleAndInput.started -= instance.OnSelectServerVisibleAndInput;
            @SelectServerVisibleAndInput.performed -= instance.OnSelectServerVisibleAndInput;
            @SelectServerVisibleAndInput.canceled -= instance.OnSelectServerVisibleAndInput;
            @SelectClient0VisibleAndInput.started -= instance.OnSelectClient0VisibleAndInput;
            @SelectClient0VisibleAndInput.performed -= instance.OnSelectClient0VisibleAndInput;
            @SelectClient0VisibleAndInput.canceled -= instance.OnSelectClient0VisibleAndInput;
            @SelectClient1VisibleAndInput.started -= instance.OnSelectClient1VisibleAndInput;
            @SelectClient1VisibleAndInput.performed -= instance.OnSelectClient1VisibleAndInput;
            @SelectClient1VisibleAndInput.canceled -= instance.OnSelectClient1VisibleAndInput;
            @SelectClient0Input.started -= instance.OnSelectClient0Input;
            @SelectClient0Input.performed -= instance.OnSelectClient0Input;
            @SelectClient0Input.canceled -= instance.OnSelectClient0Input;
            @SelectClient1Input.started -= instance.OnSelectClient1Input;
            @SelectClient1Input.performed -= instance.OnSelectClient1Input;
            @SelectClient1Input.canceled -= instance.OnSelectClient1Input;
        }

        public void RemoveCallbacks(ISelectorActions instance)
        {
            if (m_Wrapper.m_SelectorActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(ISelectorActions instance)
        {
            foreach (var item in m_Wrapper.m_SelectorActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_SelectorActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public SelectorActions @Selector => new SelectorActions(this);
    public interface IPlayerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnRotate(InputAction.CallbackContext context);
    }
    public interface ISelectorActions
    {
        void OnSelectServerVisibleAndInput(InputAction.CallbackContext context);
        void OnSelectClient0VisibleAndInput(InputAction.CallbackContext context);
        void OnSelectClient1VisibleAndInput(InputAction.CallbackContext context);
        void OnSelectClient0Input(InputAction.CallbackContext context);
        void OnSelectClient1Input(InputAction.CallbackContext context);
    }
}
