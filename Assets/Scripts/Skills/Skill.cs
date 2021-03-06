﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Skill/New Skill")]
public class Skill:ScriptableObject
{
    public float CoolDown = 10f;
    public float CurrentCoolDownTimer = 10f;
    public int SoulsCost;
    public int ManaCost = 100;
    public string Name;
    [Multiline(10)]
    public string Description = "";
    public Sprite Icon;
    public virtual void Use()
    {
       
       
    }
}
