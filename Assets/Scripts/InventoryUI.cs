using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    InventorySlot[] slots;
    Inventory Inventory;
    void Start()
    {
        //Inventory = Inventory.instance;
        //Inventory.onItemChangedCallBack += UpDateUI;
        //slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }
    void UpDateUI()
    {
        Debug.Log(slots.Length);
        //for (int i = 0; i < slots.Length; i++)
        //{
        //    if (i < Inventory.items.Count)
        //    {
        //        slots[i].AddItem(Inventory.items[i]);
        //    }
        //    else
        //    {
        //        slots[i].ClearSlot();
        //    }
        //}
    }
}
