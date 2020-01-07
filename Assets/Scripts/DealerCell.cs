using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class DealerCell : Slot, IPointerClickHandler
{
    [SerializeField] GameObject ToolTipPrebaf;
    [SerializeField] Text description;
    [SerializeField] Text ItemCost;
    private abstractItem item;
    private Inventory inventory;
    void Start()
    {
        inventory = Inventory.instance;
    }
    public override void AddItem(abstractItem _item)
    {
        item = _item;
        UiIcon.enabled = true;
        UiIcon.sprite = _item.Icon;
    }
    public override void OnPointerClick(PointerEventData eventData)
    {

        if (eventData.button == PointerEventData.InputButton.Right)
        {
            
        }
        else if (eventData.button == PointerEventData.InputButton.Left)
        {

            BuyItem();


        }

    }
    public void UpdateInfo()
    {
        if (item)
        {
            
            description.text = item.Description;
            ItemCost.text = item.Cost.ToString();
        }

    }
    public void ClosePanel()
    {
     
        description.text = null;
        ItemCost.text = null;
        
    }
    void BuyItem()
    {
        if (item)
        {
            if (Controller.instance.moneySystem.ReturnSoulsCount() >= item.Cost)
            {
                Controller.instance.moneySystem.SpendSouls(item.Cost);

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
                ClosePanel();
                item = null;
               
            }
            else
            {
                Debug.Log("Not Enough Slot InInventory");
            }
        }
    }
}
