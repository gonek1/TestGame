using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TalantSlot : MonoBehaviour, IPointerClickHandler
{
    TalantManager talantManager;
    [SerializeField] Text text;
    [SerializeField] Image icon;
    public Talant _talant;
    void Start()
    {
        talantManager = TalantManager.instance;
    }
    public void AddQuip(Talant talant)
    {
        text.text = talant.Name;
        _talant = talant;
        icon.enabled = true;
        icon.sprite = talant.Icon;
    }
    public void OnPointerClick(PointerEventData eventData)
    {

        if (eventData.button == PointerEventData.InputButton.Right)
        {
            ClearSlot();
        }


    }
    public void ClearSlot()
    {
        if (_talant)
        {
            text.text = null;
            icon.sprite = null;
            icon.enabled = false;
            talantManager.RemoveTalant(_talant);
            _talant = null;
        }
    }
}
