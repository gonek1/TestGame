using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public HealthDisplay healthDisplay;
    EnemyHealthsystem system;

    void Start()
    {
        system = new EnemyHealthsystem(100);
        healthDisplay.SetupForEnemy(system);
    }
    public void TakeDamage(int amount)
    {
        system.TakeDamage(amount);
    }
}
