using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillSlot : MonoBehaviour
{
    [SerializeField] Image Icon;
    public Skill SkillIn { get; set; }
    public void ClearSlot()
    {
        Icon = null;
        SkillIn = null;
    }
    public void AddSkill(Skill skill)
    {
        Icon.sprite = skill.UiIcon;
        SkillIn = skill;
    }
    public void Use()
    {
        SkillIn.Use();
    }
}
