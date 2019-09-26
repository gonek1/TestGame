using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEqupimentXar
{
    public int basicDamage { get; set; }
    public int basicArmor { get; set; }
    public PlayerEqupimentXar(int damage, int armor)
    {
        basicArmor = armor;
        basicDamage = damage;
    }
    public void SetItem( Quipment item)
    {
        basicDamage += item._damageMod;
        basicArmor += item._armorMod;
    }
    public void UnSetItem( Quipment item)
    {
        basicDamage -= item._damageMod;
        basicArmor -= item._armorMod;
    }
    
}
