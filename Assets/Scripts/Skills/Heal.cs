using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Skill/Heal")]
public class Heal : Skill
{
    [SerializeField] int healamount = 20;
    public override void Use()
    {
        if (CurrentCoolDownTimer < CoolDown)
        {
            Debug.Log("CoolDown!");
            return;
        }
        else
        {
            if (Controller.instance.system.GetMana() >= ManaCost && Controller.instance.system.GetPercent() != 1)
            {
                Controller.instance.system.Heal(healamount);
                Controller.instance.system.minusMana(10);
                CurrentCoolDownTimer = 0f;
            }
            
            else
            {
                Debug.Log("Максимальное здоровье!");   
            }
        }
        
    }

}
