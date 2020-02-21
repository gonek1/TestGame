using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class UpGradeSkillCell : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public UnityAction skillUp;
    Button button;
    public string description;
    public void OnPointerEnter(PointerEventData eventData)
    {
        UpGradeSystem.instance.ShowDes(description);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        UpGradeSystem.instance.ClearDes();
    }
    void Awake()
    {
        button = GetComponent<Button>();
       // button.onClick.AddListener(() => skillUp);
    }
    void LearnSkill()
    {

    }
}
