using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour,Skill
{

    GameObject FireBallPrefab;
    [SerializeField] string _name;
    [SerializeField] Sprite _Icon;
    public void Use()
    {
 
            GameObject fireball = Instantiate(Resources.Load("fireball_01") as GameObject);
            
    
    }
    void Start()
    {
        UiIcon = _Icon;
        SkillManager.instance.AddSkill(this);
    }

    public string Name { get=>_name;set=>_name = value; }
    public Sprite UiIcon { get => _Icon;  set =>_Icon = value;}
    

    public void AddToSlot(int index)
    {
        SkillManager.instance.AddSkill(this);
    }
}
