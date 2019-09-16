using UnityEngine;
using System;
public class HealthSystem
{
    private int health;
    private int mana;
    private int healthMax;
    private int manaMax;
    private int stamina;
    private int staminaMax;
    public event EventHandler OnHealthChanged;
    public event EventHandler OnManaChanged;
    public event EventHandler OnStaminaChanged;
    public event EventHandler HealthDownToZero;
    public HealthSystem(int health, int mana, int Stamina)
    {
        this.healthMax = health;
        this.manaMax = mana;
        this.health = healthMax;
        this.mana = manaMax;
        staminaMax = Stamina;
        stamina = staminaMax;
    }
    public HealthSystem(int health)
    {
        this.healthMax = health;
        this.health = healthMax;
    }
    public int GetStamina()
    {
        return stamina;
    }
    public int GetMaxStamina()
    {
        return staminaMax;
    }

    public void SetupStamina(int amount)
    {
        staminaMax += amount;
        stamina += amount;
        OnStaminaChanged?.Invoke(this, EventArgs.Empty);
    }

    public int GetHealth()
    {
        return health;
    }
    public int GetMaxHealth()
    {
        return healthMax;
    }
    
    public void SetupHealth(int amount)
    {
        healthMax += amount;
        health += amount;
        OnHealthChanged?.Invoke(this, EventArgs.Empty);
    }
    public void SetUpAgility(int amount)
    {
        staminaMax += amount;
        OnStaminaChanged?.Invoke(this, EventArgs.Empty);     
    }
    
    public void SetupMana(int amount)
    {
        manaMax += amount;
        mana += amount;
        OnManaChanged?.Invoke(this, EventArgs.Empty);
    }
    public int GetMana()
    {
        return mana;
    }
    public int GetMaxMana()
    {
        return manaMax;
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
    public void minusStamina(int amount)
    {
        stamina = Mathf.Clamp(stamina - amount, 0, staminaMax);
        OnStaminaChanged?.Invoke(this, EventArgs.Empty);
    }
    public void PlusMana(int amount)
    {
        mana = Mathf.Clamp(mana + amount, 0, manaMax);
        OnManaChanged?.Invoke(this, EventArgs.Empty);
    }
    public void PlusStamina(int amount)
    {
        stamina = Mathf.Clamp(stamina + amount, 0, staminaMax);
        OnStaminaChanged?.Invoke(this, EventArgs.Empty);
    }
    public float GetPercent()
    {
        return (float)health / healthMax;
    }
    public float GetPercentMana()
    {
        return (float)mana / manaMax;
    }
    public float GetPercentStamina()
    {
        return (float)stamina / staminaMax;
    }
    public void FullHeal()
    {
        Heal(GetMaxHealth());
        PlusMana(GetMaxMana());
        PlusStamina(GetMaxStamina());
    }


}
