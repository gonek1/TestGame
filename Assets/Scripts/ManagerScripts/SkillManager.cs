using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public static SkillManager instance;
    [SerializeField] GameObject SkillPanel;
    void Awake()
    {
        instance = this;
    }
    
    public void AddSkill(Skill skill)
    {

        for (int i = 0; i < SkillPanel.transform.childCount; i++)
        {
            
            if (SkillPanel.transform.GetChild(i).GetComponent<SkillSlot>().SkillIn ==null)
            {

                SkillPanel.transform.GetChild(i).GetComponent<SkillSlot>().AddSkill(skill);
                break;
            }
            else
            {
                Debug.Log("Нет свободных ячеек");
                return;
            }
            
        }
    }
    public void RemoveSkill()
    {

    }
    public void ReplaceSkills()
    {

    }
}
