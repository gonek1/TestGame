using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Potion", menuName = "Inventory/Potion")]
public class Potion : abstractItem
{
    public TypeOfPotion typeOfRegen;
    [SerializeField] int numberOfHeal;
    public override void Use()
    {
        
        
    }
}
