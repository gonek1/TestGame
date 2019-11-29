using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    [SerializeField] int _Cost = 100;
    public TypeOfAction type = TypeOfAction.PickUp;
    public TypeOfItem TypeOfItem;
    public string Name;
    [Multiline(10)]
    public string Description="";
    public Sprite Icon;

    public int Cost { get => _Cost; set => _Cost = value; }

    public virtual void Use(int IndexSlot)
    {

    }
}
