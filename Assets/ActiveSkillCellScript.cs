using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveSkillCellScript : Slot
{
    [SerializeField]  Skill skill;
    Text NameText;
    Text Description;
    private void OnEnable()
    {
        FindPanel();
        int index = transform.GetSiblingIndex();
        if (Controller.instance.ActiveSkills[index] !=null)
        {
            UiIcon.gameObject.SetActive(true);
            AddSkill(Controller.instance.ActiveSkills[index]);
        }
        else
        {
            UiIcon.gameObject.SetActive(false);
        }
    }
    public void OpenInfoPanel()
    {
        if (skill)
        {
            NameText.text = skill.Name;
            Description.text = skill.Description;
        }
       
    }
    public void InsertSkill()
    {
        Skill CurrentSkill = SkillManager.instance.CurrentSaveSkill;
        if (CurrentSkill)
        {
            if (skill)
            {
                SkillManager.instance.AddSkill(skill);
                Controller.instance.AddSkillToInvenory(skill);
                Remove();
            }
            AddSkill(CurrentSkill);
            Controller.instance.AddActiveSkill(transform.GetSiblingIndex(), CurrentSkill);
            SkillManager.instance.RemoveSkill();
            
        }
    }
    private void FindPanel()
    {
        NameText = transform.parent.parent.GetChild(2).GetChild(0).GetComponent<Text>();
        Description = transform.parent.parent.GetChild(2).GetChild(1).GetComponent<Text>();
       
    }

    public void ClearInfoPanel()
    {
        if (skill)
        {
            NameText.text = null;
            Description.text = null;
        }
       
    }
    public override void AddSkill(Skill skill)
    {
        UiIcon.gameObject.SetActive(true);
        UiIcon.sprite = skill.Icon;
        this.skill = skill;
    }
}
