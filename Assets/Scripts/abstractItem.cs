using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class abstractItem : ScriptableObject
{
    [SerializeField] int _Cost = 100;
    public TypeOfAction type = TypeOfAction.PickUp;
    public TypeOfRarity rarity;
    public string Name;
    [Multiline(10)]
    public string Description="";
    public Sprite Icon;
    public int Cost { get => _Cost; set => _Cost = value; }
    public virtual void Use()
    {

    }
}
public enum TypeOfPotion
{
    HealthRegen,ManagRegen,StaminaRegen
}
public enum TypeOfArmorItem
{
    Head, Chest, Legs, Shield, Feet
}
public enum TypeOfWeaponItem
{
    Melee,DoubleHand
}
public enum TypeOfRarity
{
    common, rare, epic, legendary, relic
}
