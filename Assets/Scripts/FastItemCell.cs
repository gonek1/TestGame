using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FastItemCell : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] Image icon;
    [SerializeField] abstractItem item;

    public abstractItem Item { get => item; set => item = value; }

    public void AddItem(abstractItem item)
    {
        this.Item = item;
        icon.enabled = true;
        icon.sprite = item.Icon;
    }
    public void RemoveItem()
    {
        Item = null;
        icon.enabled = false;
    }
    public void Insert()
    {
        if (Inventory.instance.IsOpen() && FastItemManager.instance.Item != null)
        {
            AddItem(FastItemManager.instance.Item);
            FastItemManager.instance.Item = null;
            FastItemManager.instance.DisableBorder();
            FastItemManager.instance.RenderIcons();
        }
    }
    public virtual void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            Insert();
        }
        else if(eventData.button == PointerEventData.InputButton.Right)
        {
            if (Item)
            {
                Inventory.instance.AddItem(Item);
                RemoveItem();
            }
            
        }
    }
}
