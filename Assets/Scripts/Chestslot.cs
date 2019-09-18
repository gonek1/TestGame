using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Chestslot : InventorySlot
{
    [SerializeField] Text ChestName;
    public override void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            int x = chestManager._chest.Items.Count;
            if (inventory.AddItem(item)) {
                
                chestManager.RemoveItemFromChest(item);
                DestroyItSelf();
                if (x -1 == 0) {
                    chestManager._chest.DestroyItSelf();
                }
            }           
        }
       
    }
    public override void AddItem(Item _item)
    {
        base.AddItem(_item);
        ChestName.text = _item.Name;
    }
}
