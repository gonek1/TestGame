using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class QuipSlot : MonoBehaviour, IPointerClickHandler
{
    public Text Name;
    public Text Description;
    QuipMentManager quipMentManager;
    public Image _image;
    [SerializeField] Quipment _quipment;
    public TypeOfItem TypeOfItem;
    

    void Start()
    {
        
        quipMentManager = QuipMentManager.instance;
    }
    public void AddQuip(Quipment quipment)
    {

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
    }
    public void ClearSlot()
    {
        if (_quipment)
        {
            Controller.instance.equpimentXar.UnSetItem(_quipment);
            _image.sprite = null;
            _image.enabled = false;
            quipMentManager.RemoveQuip(_quipment);
            _quipment = null;
        }
    }
    public void ShowInfoPanel()
    {
        if (_quipment)
        {
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
