using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Linq;

public class Inventory : MonoBehaviour
{
    public UnityEvent OnLandEvent;
    #region Singlton
    public static Inventory instance;
    void Awake()
    {
        if (instance!=null)
        {
            Debug.LogWarning("Что то не то!!!");
            return;
        }
        instance = this;
    }
    #endregion
    
    [SerializeField] Transform itemsParent;
    public InventorySlot[] slots;
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallBack;
    [SerializeField] int space = 20;
    [SerializeField] List<Item> items = new List<Item>();

    private void Start()
    {
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }
    public bool AddItem(Item item)
    {
        
        int busySlotsCount = 0;
        int freeSlotIndex = 0;
        for (int i = 0; i < items.Count; i++)
        {
            
            if (items[i] == null)
            {
                freeSlotIndex = i;
                break;
            }
            else
            {
                busySlotsCount++;
            }
        }

        if (busySlotsCount == items.Count)
        {
            
            return false;
        }
        else
        {
            
            items[freeSlotIndex] = item;
            slots[freeSlotIndex].AddItem(item);
            //onItemChangedCallBack?.Invoke();
            return true;
        }

        
    }
    public void RemoveItem(int index)
    {
        items[index] = null;       
    }
    public void Raplace(Item firstItem, Item secondItem)
    {

    }
    public void OrderByType(int type)
    {
        List<Item> itemForOder = new List<Item>();
        for (int i = 0; i < items.Count; i++)
        {
            slots[i].ClearSlotForOrder();
        }
        for (int i = 0; i < items.Count; i++)
        {
            {
                if (items[i] != null)
                {
                    if (items[i].TypeOfItem == (TypeOfItem)type)
                    {
                        itemForOder.Add(items[i]);
                    }
                }
            }
        }
        if (itemForOder.Count != 0)
        {
            for (int i = 0; i < itemForOder.Count; i++)
            {
                slots[i].AddItem(itemForOder[i]);
            }
        }
    }
    public void OnEnable()
    {
        ShowAllItems();
    }
    public void OnDisable()
    {
        
    }

    public void ShowAllItems()
    {
        if (items.Count == 0)
        {
            return;
        }
        else
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i]!=null)
                {
                    slots[i].AddItem(items[i]);
                }
               
            }
        }
    }

    public void OrderByDefend()
    {
        List<Item> itemForOder = new List<Item>();
        for (int i = 0; i < items.Count; i++)
        {
            slots[i].ClearSlotForOrder();
        }
        for (int i = 0; i < items.Count; i++)
        {
                if (items[i] != null)
                {
                    TypeOfItem[] arr = new TypeOfItem[5] { TypeOfItem.Chest, TypeOfItem.Feet, TypeOfItem.Head, TypeOfItem.Legs, TypeOfItem.Shield };
                    bool isDefend = arr.Any(a => a == items[i].TypeOfItem);
                    if (isDefend)
                    {
                        itemForOder.Add(items[i]);
                    }
                }
        }
        if (itemForOder.Count != 0)
        {
            for (int i = 0; i < itemForOder.Count; i++)
            {
                slots[i].AddItem(itemForOder[i]);
            }
        }
    }
}
public enum TypeOfItem
{
    Head, Chest, Legs, Weapon, Shield, Feet, Potion
}
