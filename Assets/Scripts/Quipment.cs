using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Quipment", menuName = "Inventory/Quipment")]
public class Quipment : abstractItem
{
    public TypeOfArmorItem TypeOfItem;
    public int defenceMof;
    public override void Use()
    { 
        Controller.instance.equpimentXar.SetArmorStats(this);
    }
}

