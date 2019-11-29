using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Skill/Hook")]
public class Hook : Skill
{
    [SerializeField] GameObject HookPrefab;
    [SerializeField] GameObject Player;
    public override void Use()
    {
        if (CurrentCoolDownTimer < CoolDown)
        {
            Debug.Log("CoolDown!");
            return;
        }
        else
        {
            CurrentCoolDownTimer = 0f;
            Player = GameObject.FindWithTag("Player");
            var hook = Instantiate(HookPrefab, Player.transform.position, Player.transform.rotation);
        }
        
    }
}
