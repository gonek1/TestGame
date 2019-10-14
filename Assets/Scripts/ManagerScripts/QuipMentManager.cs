using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuipMentManager : MonoBehaviour
{
    #region Singleton
    public static QuipMentManager instance;
    void Awake()
    {
        instance = this;
    }
    #endregion
    
    [SerializeField]Transform parentOfInventorySlot;
    Inventory inventory;
    Quipment[] currentQuipment;
    QuipSlot[] QuipSLots;
    public Transform parent;
    void Start()
    {
        QuipSLots =parent.GetComponentsInChildren<QuipSlot>();
        inventory = Inventory.instance;
        int  numSlot = System.Enum.GetNames(typeof(QuipmentSlot)).Length;
        currentQuipment = new Quipment[numSlot];
    }
    public void QuipItem(Quipment newItem, int _index)
    {
        Quipment oldItem = null;
        int slotIndex = (int)newItem.slot;
       
        inventory.RemoveItem(_index);
        parentOfInventorySlot.GetChild(_index).GetComponent<InventorySlot>().ClearSlot();
        for (int i = 0; i < QuipSLots.Length; i++)
        {
            if (QuipSLots[i].slot == newItem.slot)
            {
                QuipSLots[i].AddQuip(newItem);
            }
        }

        if (currentQuipment[slotIndex] != null)
        {
            oldItem = currentQuipment[slotIndex];
            
            inventory.AddItem(oldItem);
        }

        currentQuipment[slotIndex] = newItem;
        
    }
    public void RemoveQuip(Quipment quipment)
    {
        int slotIndex = (int)quipment.slot;
        currentQuipment[slotIndex] = null;
        inventory.AddItem(quipment);
    }
}
