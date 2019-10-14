using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Inventory : MonoBehaviour
{

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
    
    
}
