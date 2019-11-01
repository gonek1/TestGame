using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillSlot : Slot
{
    [SerializeField] Skill skillIn;

    public Skill SkillIn { get => skillIn; set => skillIn = value; }

    private void OnEnable()
    {
        Invoke("Refresh", 0.1f);
    }
    public override void AddSkill(Skill skill)
    {
        base.AddSkill(skill);
        SkillIn = skill;
        UiIcon.sprite = skill.Icon;
    }

    public override void Remove()
    {
        if (SkillIn)
        {
            SkillIn = null;
        }
      
        
    }   
    public void Use()
    {
        if (SkillIn)
        {
            SkillIn.Use();
        }
        
    }
    public void Refresh()
    {
        if (Controller.instance.ActiveSkills[transform.GetSiblingIndex()] != null)
        {
            AddSkill(Controller.instance.ActiveSkills[transform.GetSiblingIndex()]);
        }
    }
}
