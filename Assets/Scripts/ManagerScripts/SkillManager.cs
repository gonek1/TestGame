using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    [SerializeField] Skill _currentSaveSkill;
    public static SkillManager instance;
    [SerializeField] GameObject CurrentSkillPanel;

    public Skill CurrentSaveSkill { get => _currentSaveSkill; set => _currentSaveSkill = value; }
    public GameObject SkillPanel { get => CurrentSkillPanel; set => CurrentSkillPanel = value; }

    void Awake()
    {
        instance = this;
    }
    
    public void AddSkill(Skill skill)
    {

        for (int i = 0; i < SkillPanel.transform.childCount; i++)
        {
            
            if (SkillPanel.transform.GetChild(i).GetComponent<SkillInInventory>().Skill == null)
            {

                SkillPanel.transform.GetChild(i).GetComponent<SkillInInventory>().AddSkill(skill);
                break;
            }
            else
            {
                //Debug.Log("Нет свободных ячеек");
                
            }
            
        }
    }
    public void RemoveSkill()
    {
        CurrentSaveSkill = null;
    }
    public void SaveSkill(Skill skill)
    {
        if (CurrentSaveSkill)
        {
            Controller.instance.AddSkillToInvenory(CurrentSaveSkill);
            AddSkill(CurrentSaveSkill);
        }
        CurrentSaveSkill = skill;
    }
    public void UnSelectSkill()
    {
        CurrentSaveSkill = null;
    }
    public void RefreshSkills()
    {

    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (CurrentSaveSkill)
            {
                Controller.instance.AddSkillToInvenory(CurrentSaveSkill);
                AddSkill(CurrentSaveSkill);
                CurrentSaveSkill = null;
            }
        }
    }
}
