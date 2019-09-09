using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Chestslot : InventorySlot
{
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
}
