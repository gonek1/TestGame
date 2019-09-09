using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class QuipSlot : MonoBehaviour, IPointerClickHandler
{
    
    public GameObject infoPanel;
    public Text Name;
    public Text Description;
    QuipMentManager quipMentManager;
    public Image _image;
    public Text _text;
    Quipment _quipment;
    public QuipmentSlot slot;
    void Start()
    {
        quipMentManager = QuipMentManager.instance;
    }
    public void AddQuip(Quipment quipment)
    {

        _quipment = quipment;
        _text.gameObject.SetActive(false);
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
            _image.sprite = null;
            _image.enabled = false;
            _text.gameObject.SetActive(true);
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
            infoPanel.SetActive(true);
        }
        
    }
    public void ClearInfoPanel()
    {
        Name.text = null;
        Description.text = null;

    }



}
