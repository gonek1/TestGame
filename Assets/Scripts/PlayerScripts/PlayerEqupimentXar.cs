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
        weapomAttack -= item._damageMod;
        chestArmor -= item._chestrMod;
        feetArmor -= item._feetMod;
        headArmor -= item._headrMod;
        legsArmor -= item._legsMod;
        shieldArmor -= item._shieldMod;
        totalArmor = basicArmor + shieldArmor + legsArmor + headArmor + feetArmor + chestArmor;
        totalDamage -= item._damageMod;
        OnItemChanged?.Invoke(this, EventArgs.Empty);
    }
    public void SetStatsFromItem( Quipment item)
    {
        weapomAttack = item._damageMod;
        chestArmor = item._chestrMod;
        feetArmor = item._feetMod;
        headArmor = item._headrMod;
        legsArmor = item._legsMod;
        shieldArmor = item._shieldMod;
        totalArmor = basicArmor + shieldArmor + legsArmor + headArmor + feetArmor + chestArmor;
        totalDamage += weapomAttack;
        OnItemChanged?.Invoke(this, EventArgs.Empty);

    }
    
}
