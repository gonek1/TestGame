using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Quipment", menuName = "Inventory/HealthPotions")]
public class HealPoison : Item
{
    [SerializeField] int numberOfHeal;
    public override void Use(int IndexSlot)
    {
        base.Use(IndexSlot);
        if (Controller.instance.system.GetPercent() !=1)
        {
            Controller.instance.system.Heal(numberOfHeal);
            Inventory.instance.RemoveItem(IndexSlot);
            Inventory.instance.slots[IndexSlot].ClearSlot();
        }
        
    }
}
