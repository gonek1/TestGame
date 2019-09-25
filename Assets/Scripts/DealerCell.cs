using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class DealerCell : MonoBehaviour, IPointerClickHandler
{
     protected Item item;
    Inventory inventory;
    public Image icon;
    void Start()
    {
        inventory = Inventory.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public virtual void AddItem(Item _item)
    {
        item = _item;
        icon.enabled = true;
        icon.sprite = _item.Icon;
    }
    public void DestroyItSelf()
    {
        Destroy(gameObject);
    }
    public virtual void OnPointerClick(PointerEventData eventData)
    {

        if (eventData.button == PointerEventData.InputButton.Right)
        {
            
        }
        else if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (Controller.instance.system.Souls>item.Cost)
            {
                Controller.instance.system.MinusSouls(item.Cost);
            }
            else
            {
                Debug.Log("Dont enough souls!");
                return;

            }
            bool wasBought = inventory.AddItem(item);
            if (wasBought)
            {
                DestroyItSelf();
            }
            else
            {
                Debug.Log("Not EnoughSlotInInventory");
            }
           
           
        }

    }
}
