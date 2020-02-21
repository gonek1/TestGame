using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;


public class ChestPrefab : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler,IPointerClickHandler
{
    [SerializeField] Image Icon;
    [SerializeField] Image Border;
    [SerializeField] TextMeshProUGUI Name;
    [SerializeField] TextMeshProUGUI Description;
    [SerializeField] TextMeshProUGUI TypeOfItem;
    public abstractItem item;
    public void AddItem(abstractItem item)
    {
        this.item = item;
        Name.text = item.Name;
        Description.text = item.Description;
        Icon.sprite = item.Icon;
       // TypeOfItem.text = item.Name;
    }
    public void DestroyItem()
    {
        Destroy(this.gameObject);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Border.enabled = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Border.enabled = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Inventory.instance.AddItem(item);
        ChestManager.instance.RemoveItemFromChest(item);
        DestroyItem();
    }
}
