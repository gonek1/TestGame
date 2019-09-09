using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    
    public string Name;
    [Multiline(10)]
    public string Description="";
    public Sprite Icon;
    public virtual void Use(int IndexSlot)
    {

    }
}
