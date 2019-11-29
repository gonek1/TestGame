using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeFire : MonoBehaviour
{
    [SerializeField] GameObject SkillPanelInInventory;
    [SerializeField] GameObject SkillCellPrefab;
    [SerializeField] Transform Content;
    [SerializeField] List<Skill> Skills = new List<Skill>();
    [SerializeField] GameObject Panel;
    bool _IsPlayerNear = false;
    [SerializeField] TypeOfAction type = TypeOfAction.Use;
    private Controller controller;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)&& _IsPlayerNear)
        {
            SetLastIndex();
            Use();
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            if (col.gameObject.GetComponent<Controller>())
            {
               
                controller = col.gameObject.GetComponent<Controller>();
                _IsPlayerNear = true;
                if (controller.canUseOther)
                {
                    InfoManager.instance.ShowInfoPanel(type, this.gameObject);
                    

                }
            }
        }
    }

    private void SetLastIndex()
    {
        int index = controller.HomeFirePlaces.IndexOf(this.gameObject.transform);
        if (index < 0)
        {
            controller.HomeFirePlaces.Add(this.gameObject.transform);
            controller.IndexOfLastHomeFirePosiotion = controller.HomeFirePlaces.IndexOf(this.gameObject.transform);
        }
        else
        {
            controller.IndexOfLastHomeFirePosiotion = index;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        _IsPlayerNear = false;
        InfoManager.instance.CloseInfoPanel();
    }
    void Use()
    {
        
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 5);
        foreach (var item in colliders)
        {
            if (item.gameObject.CompareTag("Enemy"))
            {
                Debug.Log("Enemy is NEAR!");
                return;
            }
        }
        if (controller.canUseOther)
        {
            InfoManager.instance.CloseInfoPanel();
            OpenPanel();
            controller.SetOpenInv(false);
            controller.SetMove(false);
            SkillManager.instance.SkillPanel = SkillPanelInInventory;
        }
    }
    void OpenPanel()
    {
        Panel.SetActive(true);
    }
    void ClosePanel()
    {
        Panel.SetActive(false);
    }
    private void Start()
    {           

        UpdateSkills();
        
    }

    private void UpdateSkills()
    {
        for (int i = 0; i < Content.childCount; i++)
        {
            Content.GetChild(i).GetComponent<SkillCellSripts>().Remove();
        }
        for (int i = 0; i < Skills.Count; i++)
        {
            var cell = Instantiate(SkillCellPrefab, Content);
            cell.GetComponent<SkillCellSripts>().AddSkill(Skills[i]);
        }
    }

    public void Refresh()
    {
        int x = Controller.instance.ReturnSkills().Count;
        List<Skill> skillss = Controller.instance.ReturnSkills();
        for (int i = 0; i < x; i++)
        {
            SkillPanelInInventory.transform.GetChild(i).GetComponent<SkillInInventory>().AddSkill(skillss[i]);
        }
    }
   

}
