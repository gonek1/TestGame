// GENERATED AUTOMATICALLY FROM 'Assets/ShaderGraphs/Actions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Actions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Actions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Actions"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""b2d006cc-b6fd-488b-85b0-11b1f7f7f5b9"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""a5e0f880-7a4c-4115-91d0-65bd4428b036"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""2843e221-9436-451a-8d74-f1837c196300"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""849ebca7-6ed9-4c5d-a09c-c73f71e47ba0"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""OpenInventory"",
                    ""type"": ""Button"",
                    ""id"": ""ad0925b6-0aab-4a78-bcc4-c3b4af712278"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SwapCell"",
                    ""type"": ""Button"",
                    ""id"": ""5de3350a-69b0-49e3-953c-88fc609c89bc"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""919624e1-77fc-492a-9f5c-7755433b74d5"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""d24d2b7e-e452-4675-9af6-8d1e6c74fbf5"",
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
                    ""id"": ""b4803211-ba9f-4b9d-93be-821675ed0fed"",
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
                    ""id"": ""b6a477e4-4d79-4e9a-b097-715014004ad9"",
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
                    ""id"": ""3daadd0f-8e49-406d-94fb-8a2468ea45d5"",
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
                    ""id"": ""8d8cd70d-1a51-448e-88aa-3a1ed6b1aadf"",
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
                    ""id"": ""c762d558-912b-4965-9c5d-3bd294ca3d21"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cd14cfad-e3d1-41d0-beb5-d55d639003b1"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OpenInventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""a38e659a-6d55-4fe2-951c-c5e636b65377"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwapCell"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""900adff9-25cc-4f48-9263-754c7123bdc5"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwapCell"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""7ca14ade-fb73-4869-877d-7b92f8f66bd0"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwapCell"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""98a206ee-b603-4bdd-8cdf-c103cee73a40"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwapCell"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""5e258cb3-4695-48c1-884a-cab064cf4c5e"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwapCell"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""NPC"",
            ""id"": ""0f1ab667-dc50-4cde-9b66-a1ed8f4a40b5"",
            ""actions"": [
                {
                    ""name"": ""StartDialog"",
                    ""type"": ""Button"",
                    ""id"": ""6cf3fa3f-64c2-4a60-9724-7993770ec5cf"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""76070bd7-e73a-49da-82da-e324e347178b"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": ""Hold(duration=0.3)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StartDialog"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""DialogManager"",
            ""id"": ""711d5f30-9d14-4215-a7d0-7b63c61ef07f"",
            ""actions"": [
                {
                    ""name"": ""NextPhrase"",
                    ""type"": ""Button"",
                    ""id"": ""3b440451-7573-47c0-a713-a76c11eb92f0"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""92635176-b3ac-426b-8f5c-ed7d33a6d11c"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NextPhrase"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Items"",
            ""id"": ""0a942f0b-2a84-42c2-aac2-650b1d007342"",
            ""actions"": [
                {
                    ""name"": ""TakeItem"",
                    ""type"": ""Button"",
                    ""id"": ""22186a50-d40b-4981-a320-18c9ccf04aa2"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d8c82f0d-3e05-4e06-b4e6-7c4dbbc53d69"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TakeItem"",
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
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
        m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
        m_Player_Attack = m_Player.FindAction("Attack", throwIfNotFound: true);
        m_Player_OpenInventory = m_Player.FindAction("OpenInventory", throwIfNotFound: true);
        m_Player_SwapCell = m_Player.FindAction("SwapCell", throwIfNotFound: true);
        // NPC
        m_NPC = asset.FindActionMap("NPC", throwIfNotFound: true);
        m_NPC_StartDialog = m_NPC.FindAction("StartDialog", throwIfNotFound: true);
        // DialogManager
        m_DialogManager = asset.FindActionMap("DialogManager", throwIfNotFound: true);
        m_DialogManager_NextPhrase = m_DialogManager.FindAction("NextPhrase", throwIfNotFound: true);
        // Items
        m_Items = asset.FindActionMap("Items", throwIfNotFound: true);
        m_Items_TakeItem = m_Items.FindAction("TakeItem", throwIfNotFound: true);
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
    private readonly InputAction m_Player_Jump;
    private readonly InputAction m_Player_Move;
    private readonly InputAction m_Player_Attack;
    private readonly InputAction m_Player_OpenInventory;
    private readonly InputAction m_Player_SwapCell;
    public struct PlayerActions
    {
        private @Actions m_Wrapper;
        public PlayerActions(@Actions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputAction @Move => m_Wrapper.m_Player_Move;
        public InputAction @Attack => m_Wrapper.m_Player_Attack;
        public InputAction @OpenInventory => m_Wrapper.m_Player_OpenInventory;
        public InputAction @SwapCell => m_Wrapper.m_Player_SwapCell;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Move.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Attack.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack;
                @OpenInventory.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOpenInventory;
                @OpenInventory.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOpenInventory;
                @OpenInventory.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOpenInventory;
                @SwapCell.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSwapCell;
                @SwapCell.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSwapCell;
                @SwapCell.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSwapCell;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @OpenInventory.started += instance.OnOpenInventory;
                @OpenInventory.performed += instance.OnOpenInventory;
                @OpenInventory.canceled += instance.OnOpenInventory;
                @SwapCell.started += instance.OnSwapCell;
                @SwapCell.performed += instance.OnSwapCell;
                @SwapCell.canceled += instance.OnSwapCell;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // NPC
    private readonly InputActionMap m_NPC;
    private INPCActions m_NPCActionsCallbackInterface;
    private readonly InputAction m_NPC_StartDialog;
    public struct NPCActions
    {
        private @Actions m_Wrapper;
        public NPCActions(@Actions wrapper) { m_Wrapper = wrapper; }
        public InputAction @StartDialog => m_Wrapper.m_NPC_StartDialog;
        public InputActionMap Get() { return m_Wrapper.m_NPC; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(NPCActions set) { return set.Get(); }
        public void SetCallbacks(INPCActions instance)
        {
            if (m_Wrapper.m_NPCActionsCallbackInterface != null)
            {
                @StartDialog.started -= m_Wrapper.m_NPCActionsCallbackInterface.OnStartDialog;
                @StartDialog.performed -= m_Wrapper.m_NPCActionsCallbackInterface.OnStartDialog;
                @StartDialog.canceled -= m_Wrapper.m_NPCActionsCallbackInterface.OnStartDialog;
            }
            m_Wrapper.m_NPCActionsCallbackInterface = instance;
            if (instance != null)
            {
                @StartDialog.started += instance.OnStartDialog;
                @StartDialog.performed += instance.OnStartDialog;
                @StartDialog.canceled += instance.OnStartDialog;
            }
        }
    }
    public NPCActions @NPC => new NPCActions(this);

    // DialogManager
    private readonly InputActionMap m_DialogManager;
    private IDialogManagerActions m_DialogManagerActionsCallbackInterface;
    private readonly InputAction m_DialogManager_NextPhrase;
    public struct DialogManagerActions
    {
        private @Actions m_Wrapper;
        public DialogManagerActions(@Actions wrapper) { m_Wrapper = wrapper; }
        public InputAction @NextPhrase => m_Wrapper.m_DialogManager_NextPhrase;
        public InputActionMap Get() { return m_Wrapper.m_DialogManager; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DialogManagerActions set) { return set.Get(); }
        public void SetCallbacks(IDialogManagerActions instance)
        {
            if (m_Wrapper.m_DialogManagerActionsCallbackInterface != null)
            {
                @NextPhrase.started -= m_Wrapper.m_DialogManagerActionsCallbackInterface.OnNextPhrase;
                @NextPhrase.performed -= m_Wrapper.m_DialogManagerActionsCallbackInterface.OnNextPhrase;
                @NextPhrase.canceled -= m_Wrapper.m_DialogManagerActionsCallbackInterface.OnNextPhrase;
            }
            m_Wrapper.m_DialogManagerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @NextPhrase.started += instance.OnNextPhrase;
                @NextPhrase.performed += instance.OnNextPhrase;
                @NextPhrase.canceled += instance.OnNextPhrase;
            }
        }
    }
    public DialogManagerActions @DialogManager => new DialogManagerActions(this);

    // Items
    private readonly InputActionMap m_Items;
    private IItemsActions m_ItemsActionsCallbackInterface;
    private readonly InputAction m_Items_TakeItem;
    public struct ItemsActions
    {
        private @Actions m_Wrapper;
        public ItemsActions(@Actions wrapper) { m_Wrapper = wrapper; }
        public InputAction @TakeItem => m_Wrapper.m_Items_TakeItem;
        public InputActionMap Get() { return m_Wrapper.m_Items; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ItemsActions set) { return set.Get(); }
        public void SetCallbacks(IItemsActions instance)
        {
            if (m_Wrapper.m_ItemsActionsCallbackInterface != null)
            {
                @TakeItem.started -= m_Wrapper.m_ItemsActionsCallbackInterface.OnTakeItem;
                @TakeItem.performed -= m_Wrapper.m_ItemsActionsCallbackInterface.OnTakeItem;
                @TakeItem.canceled -= m_Wrapper.m_ItemsActionsCallbackInterface.OnTakeItem;
            }
            m_Wrapper.m_ItemsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @TakeItem.started += instance.OnTakeItem;
                @TakeItem.performed += instance.OnTakeItem;
                @TakeItem.canceled += instance.OnTakeItem;
            }
        }
    }
    public ItemsActions @Items => new ItemsActions(this);
    public interface IPlayerActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnOpenInventory(InputAction.CallbackContext context);
        void OnSwapCell(InputAction.CallbackContext context);
    }
    public interface INPCActions
    {
        void OnStartDialog(InputAction.CallbackContext context);
    }
    public interface IDialogManagerActions
    {
        void OnNextPhrase(InputAction.CallbackContext context);
    }
    public interface IItemsActions
    {
        void OnTakeItem(InputAction.CallbackContext context);
    }
}
