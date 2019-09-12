using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public HealthDisplay healthDisplay;
    HealthSystem system;

    void Start()
    {
        system = new HealthSystem(75);
        healthDisplay.Setup(system);
    }
    public void TakeDamage(int amount)
    {
        system.TakeDamage(amount);
    }
}
