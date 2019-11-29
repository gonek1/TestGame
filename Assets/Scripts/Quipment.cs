using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Quipment", menuName = "Inventory/Quipment")]
public class Quipment : Item
{
    public int _shieldMod;
    public int _damageMod;
    public int _headrMod;
    public int _chestrMod;
    public int _feetMod;
    public int _legsMod;
    
    public override void Use(int IndexSlot)
    {
        QuipMentManager.instance.QuipItem(this, IndexSlot);
        Controller.instance.equpimentXar.SetStatsFromItem(this);

    }
}

