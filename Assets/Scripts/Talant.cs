﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Quipment", menuName = "Inventory/Demon Talant")]
public class Talant : Item
{
    void Start()
    {
       
    }
    public override void Use(int IndexSlot)
    {
       // Debug.Log("Hello");

        TalantManager.instance.QuipTalant(this, IndexSlot);
        TalantManager.instance.Player.gameObject.AddComponent<HealthRegen>();

    }
}