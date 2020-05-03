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
       // Debug.Log("Hello");
        if (instance != null)
        {
            Debug.LogWarning("Что то не то!!!");
            return;
        }
        instance = this;
        Inputs = new Actions();
        Inputs.Player.SwapCell.performed +=_=>OutLineCell();
        Inputs.Player.OpenInventory.performed += _ => OpenOrCloseInventory();
    }
    public void OutLineCell(int index)
    {
        slots[index].ShowallInfoInCell();
    }
    
    public void OutLineCell()
    {
        if (IsBackPackOpen())
        {
            var value = Inputs.Player.SwapCell.ReadValue<Vector2>();
            slots[currentCell].CloseCell();
            if (value.x != 0)
            {
                if (currentCell + (int)value.x >= slots.Length)
                {
                    currentCell = 0;
                }
                else if (currentCell + (int)value.x < 0)
                {
                    currentCell = slots.Length - 1;
                }
                else
                {
                    currentCell += (int)value.x;
                }
            }
            else if (value.y != 0)
            {
                currentCell = value.y > 0 ? currentCell += -6 : currentCell += 6;
                if (currentCell > slots.Length - 1)
                {
                    currentCell = currentCell + -slots.Length;
                }
                else if (currentCell < 0)
                {
                    currentCell = currentCell + slots.Length;
                }
            }
            slots[currentCell].ShowallInfoInCell();
        }
    }
    #endregion
    private int currentCell = 0;
    [SerializeField] Transform itemsParent;
    private InventorySlot[] slots;
    [SerializeField] int space = 20;
    [SerializeField] List<abstractItem> items = new List<abstractItem>();
    [SerializeField] GameObject inventoryItem;
    [SerializeField] GameObject[] inventoryTabs;
    [SerializeField] TextMeshProUGUI name;
    [SerializeField] TextMeshProUGUI description;
    [SerializeField] TextMeshProUGUI stats;
    [SerializeField] TextMeshProUGUI rarityText;
    [SerializeField] Image rarity;
    [SerializeField] GameObject backPack;
    private Actions Inputs;
    private bool isOpen = false;
    public List<abstractItem> Items { get => items; set => items = value; }
    public bool IsOpen { get => isOpen; set => isOpen = value; }

    private void Start()
    {
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
        ShowAllItems();
    }

    public bool IsBackPackOpen()
    {
        return backPack.activeSelf;
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
        for (int i = 0; i < inventoryTabs.Length; i++)
        {
            if (i == index)
            {
                inventoryTabs[i].SetActive(true);
            }
            else
            {
                inventoryTabs[i].SetActive(false);
            }
        }
        ShowAllItems();
        currentCell = 0;
        OutLineCell(0);
        Controller.instance.canUseOther = false;
        tabControl.UpDateTabname(index);
        inventoryItem.SetActive(true);
        Controller.instance.SetMove(false);
        Controller.instance.CanAttack = false;
        FastItemManager.instance.DisableBorder();
    }
    public void CloseInventory()
    {
        slots[currentCell].CloseCell();
        currentCell = 0;
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
        rarityText.text = item.rarity.ToString();
        rarity.color = ReturnRarirtColor(item);
        stats.text = description;
        name.text = item.Name;
        this.description.text = item.Description;
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
        stats.text = null;
        name.text = null;
        description.text = null;
        rarityText.text = null;
        rarity.color = Color.white;
        
    }
    public void ShowInfoAboutItem(abstractItem item)
    {
        if (item is Weapon)
        {
            Weapon weapon = item as Weapon;
            stats.text = "Урон " + weapon.damageMod;
        }
        else if (item is Quipment)
        {
            Quipment weapon = item as Quipment;
            stats.text = "Броня " + weapon.defenceMof;
        }
        rarityText.text = item.rarity.ToString();
        name.text = item.name;
        description.text = item.Description;
        rarity.color = ReturnRarirtColor(item);
    }
    private void OpenOrCloseInventory()
    {
        Debug.Log("Test123");
        bool canOpen = Controller.instance.CanOpenInv;
        if (canOpen)
        {
            IsOpen = !IsOpen;
            if (IsOpen)
            {
                OpenInventory(1);
            }
            else if (!IsOpen)
            {
                CloseInventory();
            }
        }
    }

}
public enum TypeOfQuipSlot
{
    Head, Chest,Weapon, Legs, Shield, Feet
}

