using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Slot : MonoBehaviour
{
    public Image UiIcon;
    public Text descriprion;
    public string Name;
    public virtual void Add() // добавление слота 
    {

    }
    public virtual void Remove() // очистка слота
    {
        UiIcon.sprite = null;
        descriprion = null;
        Name = null;
    }
    public virtual void DestroyItSelf() // уничтожение слота
    {
        Destroy(gameObject);
    }
    public virtual void OnPointerClick(PointerEventData eventData)// нажатие на слот
    {

    }
    public virtual void AddSkill(Skill skill)
    { 

    }
    public virtual void AddItem(abstractItem item)
    {

    }
    public virtual void AddQuip(Talant talant)
    {

    }
}
