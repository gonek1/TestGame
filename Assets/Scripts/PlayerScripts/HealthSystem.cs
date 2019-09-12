using UnityEngine;
using System;
public class HealthSystem
{
    private int health;
    private int mana;
    private int healthMax;
    private int manaMax;
    public event EventHandler OnHealthChanged;
    public event EventHandler OnManaChanged;
    public event EventHandler HealthDownToZero;
    public HealthSystem(int health, int mana)
    {
        this.healthMax = health;
        this.manaMax = mana;
        this.health = healthMax;
        this.mana = manaMax;
    }
    public HealthSystem(int health)
    {
        this.healthMax = health;
        this.health = healthMax;
    }
    public int GetHealth()
    {
        return health;
    }
    public int GetMana()
    {
        return mana;
    }
    public void TakeDamage(int amount)
    {
        health = Mathf.Clamp(health - amount, 0, healthMax);
        OnHealthChanged?.Invoke(this, EventArgs.Empty);
        if (health <=0 )
        {
            HealthDownToZero?.Invoke(this, EventArgs.Empty);
        }
    }
    public void Heal(int amount)
    {
        health = Mathf.Clamp(health + amount, 0, healthMax);
        OnHealthChanged?.Invoke(this, EventArgs.Empty);

    }
    public void minusMana(int amount)
    {
        mana = Mathf.Clamp(mana - amount, 0, manaMax);
        OnManaChanged?.Invoke(this, EventArgs.Empty);
    }
    public void PlusMana(int amount)
    {
        mana = Mathf.Clamp(mana + amount, 0, manaMax);
        OnManaChanged?.Invoke(this, EventArgs.Empty);
    }
    public float GetPercent()
    {
        return (float)health / healthMax;
    }
    public float GetPercentMana()
    {
        return (float)mana / manaMax;
    }
    
    
}
