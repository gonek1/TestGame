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
    
    [SerializeField]Transform parentOfInventorySlot;// инвентарь
    Inventory inventory;// скрипт инвентаря
    [SerializeField]Quipment[] currentQuipment;//экипировка
    QuipSlot[] QuipSLots;
    public Transform parent;
    void Start()
    {
        QuipSLots =parent.GetComponentsInChildren<QuipSlot>();
        inventory = Inventory.instance;
        currentQuipment = new Quipment[6];
    }
    public void QuipItem(Quipment newItem, int _index)
    {
        Quipment oldItem = null;
        int slotIndex = (int)newItem.TypeOfItem;
        inventory.RemoveItem(_index);
        parentOfInventorySlot.GetChild(_index).GetComponent<InventorySlot>().ClearSlot();
        for (int i = 0; i < QuipSLots.Length; i++)
        {
            if (QuipSLots[i].TypeOfItem == newItem.TypeOfItem)
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
        int slotIndex = (int)quipment.TypeOfItem;
        currentQuipment[slotIndex] = null;
        inventory.AddItem(quipment);
    }
}
