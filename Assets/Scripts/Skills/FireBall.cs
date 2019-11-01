﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Skill/FireBall")]
public class FireBall : Skill
{
    [SerializeField] float speed = 100f;
    [SerializeField] GameObject FireBallPrefab;
    GameObject  Player;
    public override void Use()
    {
        Player = GameObject.FindWithTag("Player");
        if ( Controller.instance.system.GetMana() >= ManaCost)
        {
            Controller.instance.system.minusMana(ManaCost);
            var fireBall =  Instantiate(FireBallPrefab, Player.transform.position,Player.transform.rotation);
           // fireBall.GetComponent<Rigidbody2D>().AddForce(Player.transform.right * speed);
                
        }
        else
        {
            Debug.Log("Не хватает маны!");
        }
    }
 

    public void AddToSlot()
    {
        SkillManager.instance.AddSkill(this);
    }
}
