using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using TMPro;

public class InventorySlot : MonoBehaviour, /*IBeginDragHandler, IEndDragHandler, IDragHandler,*/
    IPointerClickHandler
{
    public GameObject ItemPrefab;
    public Text Name;
    public Text Description;
    public int IndexSlot;
    public Transform playerPosToDrop;
    protected Inventory inventory;
    protected ChestManager chestManager;
    protected Item item;
    public Image icon;
    [SerializeField] TextMeshProUGUI stats;
    
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
    void Start()
    {
       // stats.text = "Test <color=green>Test</color>";
        chestManager = ChestManager.instance;
       IndexSlot = transform.GetSiblingIndex();
        inventory = Inventory.instance;
    }
 
    public void ClearSlot()
    {
        if (item)
        {
            icon.sprite = null;
            icon.enabled = false;
            
            inventory.RemoveItem(IndexSlot);
            item = null;
            ClearInfoPanel();
        }
    }
    public void ClearSlotForOrder()
    {
        if (item)
        {
            icon.sprite = null;
            icon.enabled = false;
            item = null;
           
        }
    }

    private void SpawnItem()
    {
        var prebaf = Instantiate(ItemPrefab, playerPosToDrop.position, transform.rotation);
        prebaf.GetComponent<ItemPick>().Item = item;
    }
    public virtual void OnPointerClick(PointerEventData eventData)
    {
       
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            SpawnItem();
            ClearSlot();
        }
        else if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (item)
                item.Use(IndexSlot);
        }

    }
    public void ShowInfoPanel()
    {
        if (item)
        {
            Name.text = item.name;
            Description.text = item.Description;
        }
        else if (!item)
        {
            ClearInfoPanel();
        }
    }
    public void ClearInfoPanel()
    {
        Name.text = null;
        Description.text = null;
    }


}
