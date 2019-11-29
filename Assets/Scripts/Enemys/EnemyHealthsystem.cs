using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthsystem
{
    private int health;
    private int healthMax;
    public event EventHandler EnemyHealthDownToZero;
    public event EventHandler OnHealthChanged;
    public EnemyHealthsystem(int health)
    {
        this.healthMax = health;
        this.health = healthMax;
    }
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void TakeDamage(int amount)
    {
       
        health = Mathf.Clamp(health - amount, 0, healthMax);
        OnHealthChanged?.Invoke(this, EventArgs.Empty);
        
        if (health <= 0)
        {
            EnemyHealthDownToZero?.Invoke(this, EventArgs.Empty);
        }

    }
    public float GetPercent()
    {
        return (float)health / healthMax;
    }
}
