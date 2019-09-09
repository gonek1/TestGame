using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Quipment", menuName = "Inventory/Quipment")]
public class Quipment : Item
{
   
    void Start()
    {
        
       
    }
    public QuipmentSlot slot;
    public int _armorMod;
    public int _damageMod;
    public override void Use(int IndexSlot)
    {
        
        QuipMentManager.instance.QuipItem(this, IndexSlot);
    }
}
public enum QuipmentSlot{
       Head, Chest, Legs, Weapon, Shield , Feet
}
