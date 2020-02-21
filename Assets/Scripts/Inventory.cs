using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class Inventory : MonoBehaviour
{
    
    [SerializeField] TabControlManager tabControl;
    #region Singlton
    public static Inventory instance;
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Что то не то!!!");
            return;
        }
        instance = this;
        Inputs = new Actions();
        Inputs.Player.SwapCell.performed += SwapCell;
    }

    private void SwapCell(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        throw new System.NotImplementedException();
    }
    #endregion
    [SerializeField] Transform itemsParent;
    public InventorySlot[] slots;
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallBack;
    [SerializeField] int space = 20;
    [SerializeField] List<abstractItem> items = new List<abstractItem>();
    [SerializeField] GameObject inventoryItem;
    [SerializeField] GameObject[] InventoryTabs;
    [SerializeField] TextMeshProUGUI Name;
    [SerializeField] TextMeshProUGUI Description;
    [SerializeField] TextMeshProUGUI Stats;
    [SerializeField] TextMeshProUGUI RarityText;
    [SerializeField] Image Rarity;
    Actions Inputs;
    
    public List<abstractItem> Items { get => items; set => items = value; }

    private void Start()
    {
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
        ShowAllItems();
    }
    public bool IsOpen()
    {
        return inventoryItem.activeSelf;
    }
    public bool AddItem(abstractItem item)
    {

        int busySlotsCount = 0;
        int freeSlotIndex = 0;
        for (int i = 0; i < Items.Count; i++)
        {

            if (Items[i] == null)
            {
                freeSlotIndex = i;
                break;
            }
            else
            {
                busySlotsCount++;
            }
        }

        if (busySlotsCount == Items.Count)
        {

            return false;
        }
        else
        {

            Items[freeSlotIndex] = item;
            slots[freeSlotIndex].AddItem(item);
            //onItemChangedCallBack?.Invoke();
            return true;
        }


    }
    public void RemoveItemFromCraft(abstractItem item)
    {
        int index = Items.IndexOf(item);
        Items[index] = null;
        slots[index].ClearSlot();
    }
    public void RemoveItemForTime(int index)
    {
        Items[index] = null;
        slots[index].ClearSlotNotFull();
    }
    //public void OrderByType(int type)
    //{
    //    List<abstractItem> itemForOder = new List<abstractItem>();
    //    for (int i = 0; i < items.Count; i++)
    //    {
    //        slots[i].ClearSlotForOrder();
    //    }
    //    for (int i = 0; i < items.Count; i++)
    //    {
    //        {
    //            if (items[i] != null)
    //            {
    //                if (items[i].TypeOfItem == (TypeOfItem)type)
    //                {
    //                    itemForOder.Add(items[i]);
    //                }
    //            }
    //        }
    //    }
    //    if (itemForOder.Count != 0)
    //    {
    //        for (int i = 0; i < itemForOder.Count; i++)
    //        {
    //            slots[i].AddItem(itemForOder[i]);
    //        }
    //    }
    //}
    public void OnEnable()
    {
        Inputs.Player.SwapCell.Enable();
    }
    public void OnDisable()
    {
        Inputs.Player.SwapCell.Disable();
    }

    public void ShowAllItems()
    {
        if (Items.Count == 0)
        {
            return;
        }
        else
        {
            for (int i = 0; i < Items.Count; i++)
            {
                if (Items[i] != null)
                {
                    slots[i].AddItem(Items[i]);
                }

            }
        }
    }

    //public void OrderByDefend()
    //{
    //    List<abstractItem> itemForOder = new List<abstractItem>();
    //    for (int i = 0; i < items.Count; i++)
    //    {
    //        slots[i].ClearSlotForOrder();
    //    }
    //    for (int i = 0; i < items.Count; i++)
    //    {
    //        if (items[i] != null)
    //        {
    //            TypeOfItem[] arr = new TypeOfItem[5] { TypeOfItem.Chest, TypeOfItem.Feet, TypeOfItem.Head, TypeOfItem.Legs, TypeOfItem.Shield };
    //            bool isDefend = arr.Any(a => a == items[i].TypeOfItem);
    //            if (isDefend)
    //            {
    //                itemForOder.Add(items[i]);
    //            }
    //        }
    //    }
    //    if (itemForOder.Count != 0)
    //    {
    //        for (int i = 0; i < itemForOder.Count; i++)
    //        {
    //            slots[i].AddItem(itemForOder[i]);
    //        }
    //    }
    //}
    public void OpenInventory(int index)
    {
        for (int i = 0; i < InventoryTabs.Length; i++)
        {
            if (i == index)
            {
                InventoryTabs[i].SetActive(true);
            }
            else
            {
                InventoryTabs[i].SetActive(false);
            }
        }
        ShowAllItems();
        Controller.instance.canUseOther = false;
        tabControl.UpDateTabname(index);
        inventoryItem.SetActive(true);
        Controller.instance.SetMove(false);
        Controller.instance.CanAttack = false;
        FastItemManager.instance.DisableBorder();
    }
    public void CloseInventory()
    {
        Controller.instance.canUseOther = true;
        inventoryItem.SetActive(false);
        Controller.instance.SetMove(true);
        Controller.instance.CanAttack = true;
        FastItemManager.instance.DisableBorder();
    }
    public void CompareItem(abstractItem item)
    {
        string colorText = "";
        string description = "";
        if (item is Quipment)
        {
            Quipment ITEM = item as Quipment;
            int x = ITEM.defenceMof - Controller.instance.equpimentXar.quipmentArmor;
            if (x < 0)
            {

                colorText = "red";
            }
            else if (x > 0)
            {

                colorText = "green";
            }
            else if (x == 0)
            {

                colorText = "white";
            }
            description += "Броня : " + "<color=" + colorText + ">" + x + "</color>";
        }
        else if (item is Weapon)
        {
            Weapon ITEM = item as Weapon;
            int x = ITEM.damageMod - Controller.instance.equpimentXar.weapomAttack;
            if (x < 0)
            {
                colorText = "red";
            }
            else if (x > 0)
            {

                colorText = "green";
            }
            else if (x == 0)
            {

                colorText = "white";
            }

            description += "Урон : " + "<color=" + colorText + ">" + x + "</color>";
        }
        RarityText.text = item.rarity.ToString();
        Rarity.color = ReturnRarirtColor(item);
        Stats.text = description;
        Name.text = item.Name;
        Description.text = item.Description;
    }

    private Color ReturnRarirtColor(abstractItem item)
    {
        Color color = new Color();
        if (item.rarity == TypeOfRarity.common)
        {
            color = Color.white;
        }
        else if (item.rarity == TypeOfRarity.rare)
        {
            color = Color.blue;
        }
        else if (item.rarity == TypeOfRarity.epic)
        {
            color = new Color(128, 0, 128);
        }
        else if (item.rarity == TypeOfRarity.legendary)
        {
            color = Color.yellow;
        }
        else if (item.rarity == TypeOfRarity.legendary)
        {
            color = new Color(255, 140, 0);
        }
        return color;
    }

    public void ClearInfoPanel()
    {
        Stats.text = null;
        Name.text = null;
        Description.text = null;
        RarityText.text = null;
        Rarity.color = Color.white;
        
    }
    public void ShowInfoAboutItem(abstractItem item)
    {
        if (item is Weapon)
        {
            Weapon weapon = item as Weapon;
            Stats.text = "Урон " + weapon.damageMod;
        }
        else if (item is Quipment)
        {
            Quipment weapon = item as Quipment;
            Stats.text = "Броня " + weapon.defenceMof;
        }
        RarityText.text = item.rarity.ToString();
        Name.text = item.name;
        Description.text = item.Description;
        Rarity.color = ReturnRarirtColor(item);
    }
    
}
public enum TypeOfQuipSlot
{
    Head, Chest,Weapon, Legs, Shield, Feet
}

