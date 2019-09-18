using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, /*IBeginDragHandler, IEndDragHandler, IDragHandler,*/
    IPointerClickHandler
{

    public GameObject ItemPrefab;
    public GameObject infoPanel;
    public Text Name;
    public Text Description;
    public int IndexSlot;
    public Transform playerPosToDrop;
    protected Inventory inventory;
    protected ChestManager chestManager;
    //public Transform sometransform;
    //public Transform Parent;
   protected Item item;
    public Image icon;
    
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

    private void SpawnItem()
    {
        var prebaf = Instantiate(ItemPrefab, playerPosToDrop.position, transform.rotation);
        prebaf.GetComponent<ItemPick>().Item = item;
    }


    //public void OnBeginDrag(PointerEventData eventData)
    //{
    //    transform.SetParent(sometransform, false);
    //}

    //public void OnEndDrag(PointerEventData eventData)
    //{

    //    InsertToGrid();

    //}

    //private void InsertToGrid()
    //{
    //    int closestIndex = 0;
    //    for (int i = 0; i < Parent.transform.childCount; i++)
    //    {
    //        if (Vector3.Distance(transform.position, Parent.GetChild(i).position) <
    //            Vector3.Distance(transform.position, Parent.GetChild(closestIndex).position))
    //        {
    //            closestIndex = i;
    //        }
    //    }
    //    transform.SetParent(Parent, false);
    //    transform.SetSiblingIndex(closestIndex);
    //}

    //public void OnDrag(PointerEventData eventData)
    //{
    //    transform.position = Input.mousePosition;
    //}
    //private bool In(RectTransform originalParent)
    //{
    //    return originalParent.rect.Contains(transform.position);
    //}
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
            infoPanel.SetActive(true);
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
