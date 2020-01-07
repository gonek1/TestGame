using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEqupimentXar
{
    public event EventHandler OnItemChanged;
    public int basicArmor { get; set; }
    public int quipmentArmor { get; set; }
    public int totalArmor { get; set; }
    public int basicDamage { get; set; }
    public int weapomAttack { get; set; }
    public int totalDamage { get; set; }
 
    public PlayerEqupimentXar(int damage, int armor)
    {
        basicArmor = armor;
        basicDamage = damage;
        totalDamage = basicDamage;
        totalArmor = basicArmor;
    }
    public void UnSetQuipment( Quipment quipment)
    {
        quipmentArmor = 0;
        totalArmor -= quipment.defenceMof;
        OnItemChanged?.Invoke(this, EventArgs.Empty);
    }
    public void UnSetWeapon(Weapon weapon)
    {
        weapomAttack = 0;
        totalDamage -= weapon.damageMod;
        OnItemChanged?.Invoke(this, EventArgs.Empty);
    }
    public void SetArmorStats( Quipment quipment)
    {
        quipmentArmor = quipment.defenceMof;
        totalArmor += quipmentArmor;
        OnItemChanged?.Invoke(this, EventArgs.Empty);
    }
    public void SetWeaponStats(Weapon weapon)
    {
        weapomAttack = weapon.damageMod;
        totalDamage += weapomAttack;
        OnItemChanged?.Invoke(this, EventArgs.Empty);

    }

}
