using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class DealerCell : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] GameObject ShopInfoPanel;
    [SerializeField] GameObject ToolTipPrebaf;
    [SerializeField] Text description;
    [SerializeField] Text ItemCost;
    private Item item;
    private Inventory inventory;
    [SerializeField] Image icon;
    void Start()
    {
        
        inventory = Inventory.instance;
    }
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

            BuyItem();


        }

    }
    public void UpdateInfo()
    {
        if (item)
        {
            ShopInfoPanel.SetActive(true);
            description.text = item.Description;
            ItemCost.text = item.Cost.ToString();
        }

    }
    public void ClosePanel()
    {
        
        ShopInfoPanel.SetActive(false);
        description.text = null;
        ItemCost.text = null;
        
    }
    void BuyItem()
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
        }
        else
        {
            Debug.Log("Not Enough Slot InInventory");
        }
    }
}
