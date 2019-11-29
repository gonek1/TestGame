using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEqupimentXar
{
    public event EventHandler OnItemChanged;
    public int basicArmor { get; set; }
    public int basicDamage { get; set; }
    public int totalDamage { get; set; }
    public int weapomAttack { get; set; }
    public int totalArmor { get; set; }
    public int chestArmor { get; set; }
    public int headArmor { get; set; }
    public int shieldArmor { get; set; }
    public int feetArmor { get; set; }
    public int legsArmor { get; set; }
    public PlayerEqupimentXar(int damage, int armor)
    {
        basicArmor = armor;
        basicDamage = damage;
        totalDamage = basicDamage;
    }
    public void UnSetItem( Quipment item)
    {
        if (item.TypeOfItem == TypeOfItem.Weapon)
        {
            weapomAttack -= item._damageMod;
        }
        else if (item.TypeOfItem == TypeOfItem.Chest)
        {
            chestArmor -= item._chestrMod;
        }
        else if (item.TypeOfItem == TypeOfItem.Feet)
        {
            feetArmor -= item._feetMod;
        }
        else if (item.TypeOfItem == TypeOfItem.Head)
        {
            headArmor -= item._headrMod;
        }
        else if (item.TypeOfItem == TypeOfItem.Legs)
        {
            legsArmor -= item._legsMod;
        }
        else if (item.TypeOfItem == TypeOfItem.Shield)
        {
            shieldArmor -= item._shieldMod;
        }
        totalArmor = basicArmor + shieldArmor + legsArmor + headArmor + feetArmor + chestArmor;
        totalDamage = basicDamage;
        OnItemChanged?.Invoke(this, EventArgs.Empty);
    }
    public void SetStatsFromItem( Quipment item)
    {
        if (item.TypeOfItem == TypeOfItem.Weapon)
        {
            weapomAttack = item._damageMod;
        }
        else if (item.TypeOfItem == TypeOfItem.Chest)
        {
            chestArmor = item._chestrMod;
        }
        else if (item.TypeOfItem == TypeOfItem.Feet)
        {
            feetArmor = item._feetMod;
        }
        else if (item.TypeOfItem == TypeOfItem.Head)
        {
            headArmor = item._headrMod;
        }
        else if (item.TypeOfItem == TypeOfItem.Legs)
        {
            legsArmor = item._legsMod;
        }
        else if (item.TypeOfItem == TypeOfItem.Shield)
        {
            shieldArmor = item._shieldMod;
        }
        totalArmor = basicArmor + shieldArmor + legsArmor + headArmor + feetArmor + chestArmor;
        totalDamage = basicDamage + weapomAttack;
        OnItemChanged?.Invoke(this, EventArgs.Empty);

    }
    
}
