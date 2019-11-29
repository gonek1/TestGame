using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillSlot : Slot
{
    [SerializeField] Skill skillIn;
    Image image;
    public Skill SkillIn { get => skillIn; set => skillIn = value; }

    private void OnEnable()
    {
        Refresh();
        image = GetComponent<Image>();
        image.fillAmount = SkillIn.CurrentCoolDownTimer / skillIn.CoolDown;
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
    void Update()
    {
        if (skillIn)
        {
            skillIn.CurrentCoolDownTimer = Mathf.Clamp(skillIn.CurrentCoolDownTimer + Time.deltaTime, 0, skillIn.CoolDown);
            image.fillAmount = SkillIn.CurrentCoolDownTimer / skillIn.CoolDown;
        }
       
    }
    public void Use()
    {
        if (SkillIn)
        {
                image.type = Image.Type.Filled;
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
