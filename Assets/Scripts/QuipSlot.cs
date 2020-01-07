using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class QuipSlot : MonoBehaviour, IPointerClickHandler
{
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Description;
    public TextMeshProUGUI Stats;
    public Image Boder;
    public Image _image;
    [SerializeField] abstractItem _quipment;
    public TypeOfQuipSlot TypeOfQuipSlot;
    void Start()
    {
    }
    public void ShowBorder()
    {
        Boder.enabled = true;
    }
    public void TurnOffBorder()
    {
        Boder.enabled = false;
    }
    public void AddQuip(abstractItem quipment)
    {
        if (_quipment != null)
        {
            Inventory.instance.AddItem(_quipment);
            _quipment = null;
        }
        _quipment = quipment;
        _image.enabled = true;
        _image.sprite = quipment.Icon;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            ClearSlot();
        }
        else if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (FastItemManager.instance.Item is Quipment)
            {
                Quipment qp = FastItemManager.instance.Item as Quipment;
                if (qp.TypeOfItem.ToString() == TypeOfQuipSlot.ToString())
                {
                    AddQuip(FastItemManager.instance.Item as Quipment);
                    _quipment.Use();
                    FastItemManager.instance.Item = null;
                    FastItemManager.instance.DisableBorder();
                }
            }
            else if (FastItemManager.instance.Item is Weapon && TypeOfQuipSlot== TypeOfQuipSlot.Weapon)
            {
                AddQuip(FastItemManager.instance.Item as Weapon);
                Weapon weapon = FastItemManager.instance.Item as Weapon;
                weapon.Use();
                FastItemManager.instance.Item = null;
                FastItemManager.instance.DisableBorder();
            }
        }
    }
    public void ClearSlot()
    {
        if (_quipment)
        {
            if (_quipment is Quipment)
            {
                Controller.instance.equpimentXar.UnSetQuipment(_quipment as Quipment);
            }
            else if( _quipment is Weapon)
            {
                Controller.instance.equpimentXar.UnSetWeapon(_quipment as Weapon);
            }
            _image.sprite = null;
            _image.enabled = false;
            Inventory.instance.AddItem(_quipment);
            _quipment = null;
        }
    }
    public void ShowInfoPanel()
    {
        if (_quipment)
        {
            if (_quipment is Weapon)
            {
                Weapon weapon = _quipment as Weapon;
                Stats.text = "Урон " + weapon.damageMod;
            }
            else if (_quipment is Quipment)
            {
                Quipment weapon = _quipment as Quipment;
                Stats.text = "Броня " + weapon.defenceMof;
            }
            Name.text = _quipment.name;
            Description.text = _quipment.Description;
        }
        
    }
    public void ClearInfoPanel()
    {
        Name.text = null;
        Description.text = null;
    }



}
