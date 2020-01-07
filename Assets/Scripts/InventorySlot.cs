using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using TMPro;

public class InventorySlot : MonoBehaviour, /*IBeginDragHandler, IEndDragHandler, IDragHandler,*/
    IPointerClickHandler
{   
    public GameObject ItemPrefab;
    public int IndexSlot;
    public Transform playerPosToDrop;
    protected Inventory inventory;
    protected ChestManager chestManager;
    protected abstractItem item;
    public Image icon;
    
    public virtual void AddItem(abstractItem _item)
    {
        //Debug.Log(transform.GetSiblingIndex());
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
            
            inventory.RemoveItem(item);
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
            if (item !=null)
            {
                SpawnItem();
                ClearSlot();
            }
            
        }
        else if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (item!=null)
            {          
               FastItemManager.instance.OutLineBorder(item);
               ClearSlot();
                //item.Use(IndexSlot); 
            }
            
        }

    }
    public void ShowInfoPanel()
    {
        if (item !=null)
        {
            inventory.CompareItem(item);
        }
    }
    public void ClearInfoPanel()
    {
        inventory.ClearInfoPanel();
    }

    public void Test()
    {
        Debug.Log("Test");
    }
}
