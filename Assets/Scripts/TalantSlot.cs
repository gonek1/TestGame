using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TalantSlot : Slot, IPointerClickHandler
{
    TalantManager talantManager;
    [SerializeField] Text text;
   
    public Talant _talant;
    void Start()
    {
        talantManager = TalantManager.instance;
    }
    public override void AddQuip(Talant talant)
    {
        text.text = talant.Name;
        _talant = talant;
        UiIcon.enabled = true;
        UiIcon.sprite = talant.Icon;
    }
    public override void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            Remove();
        }
    }
    public override void Remove()
    {
        if (_talant)
        {
            text.text = null;
            UiIcon.sprite = null;
            UiIcon.enabled = false;
            talantManager.RemoveTalant(_talant);
            _talant = null;
        }
    }
}
