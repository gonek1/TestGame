using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillCellSripts : Slot
{
    Skill skill;
    Transform Panel;
    Text Text_Name;
    Text Description;
    Text Cost;
    
    private void OnEnable()
    {
        FindPanel();
    }
    public override void Remove()
    {
        base.Remove();
        skill = null;
        UiIcon = null;
    }

    private void FindPanel()
    {
        Panel = transform.parent.parent.GetChild(1);
        Text_Name = Panel.GetChild(0).GetComponent<Text>();
        Description = Panel.GetChild(1).GetComponent<Text>();
        Cost = Panel.GetChild(2).GetComponent<Text>();
    }
    public override void AddSkill(Skill skill)
    {
        this.skill = skill;
        UiIcon.sprite = skill.Icon;
        
    }
    public void OpenInfoPanel()
    {
        Text_Name.text = skill.Name;
        Description.text = skill.Description;
        Cost.text = "COST :  "+ skill.SoulsCost.ToString();
    }
    public void ClosePanel()
    {
        Text_Name.text = null;
        Description.text = null;
        Cost.text = null;
    }
    public void AddToPlayer()
    {
        
        if (skill)
        {
            if (Controller.instance.moneySystem.ReturnSoulsCount()>=skill.SoulsCost)
            {
                Controller.instance.moneySystem.SpendSouls(skill.SoulsCost);
                Controller.instance.AddSkillToInvenory(skill);
                Destroy(this.gameObject);
                ClosePanel();
            }
            else
            {
                Debug.Log("Not enough souls!");
            }
            
        }
        
    }

}
