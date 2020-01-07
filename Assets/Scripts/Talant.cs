using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Quipment", menuName = "Inventory/Demon Talant")]
public class Talant : abstractItem
{
    void Start()
    {
       
    }
    public override void Use()
    {
       // TalantManager.instance.QuipTalant(this, IndexSlot);
        TalantManager.instance.Player.gameObject.AddComponent<HealthRegen>();
        TalantManager.instance.Render(this);
    }
}
