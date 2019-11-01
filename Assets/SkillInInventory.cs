using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillInInventory : MonoBehaviour
{
    [SerializeField] Image SkillIcon;
    Skill skill;

    public Skill Skill { get => skill; set => skill = value; }

    public void SendSkillToManager()
    {
        if (Skill)
        {
            SkillManager.instance.SaveSkill(Skill);
            Controller.instance.RemoveSkillFromInvenory(Skill);
            RemoveSkill();

        }

    }
    public void AddSkill(Skill _skill)
    {
        Skill = _skill;
        SkillIcon.gameObject.SetActive(true);
        SkillIcon.sprite = _skill.Icon;
    }
    public void RemoveSkill()
    {
        gameObject.GetComponent<Image>().color = Color.white;
        Skill = null;
        SkillIcon.gameObject.SetActive(false);
    }
    public void ShowInfo()
    {
        if (Skill)
        {
            Transform panel = transform.parent.parent.GetChild(2);
            Text name = panel.GetChild(0).GetComponent<Text>();
            Text description = panel.GetChild(1).GetComponent<Text>();
            name.text = Skill.Name;
            description.text = Skill.Description;
        }
    }
    public void CloseInfo()
    {
        Transform panel = transform.parent.parent.GetChild(2);
        Text name = panel.GetChild(0).GetComponent<Text>();
        Text description = panel.GetChild(1).GetComponent<Text>();
        name.text = "";
        description.text = "";
    }
    public void ChangeColor()
    {
        if (Skill)
        {
            gameObject.GetComponent<Image>().color = Color.red;
        }
    }
}
