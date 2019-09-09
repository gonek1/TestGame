using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestManager : MonoBehaviour
{
    
    #region Singlton
    public static ChestManager instance;
    
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Что то не то!!!");
            return;
        }
        instance = this;
    }

    #endregion
    public Chest _chest;
    public Transform content;
    public GameObject CellPrebaf;
    public List<Item> items;
    void Start()
    {
        
    }

    public void Render(List<Item> _items,Chest chest)
    {
        _chest = chest;
        for (int i = 0; i < _items.Count; i++)
        {
            var Cell =  Instantiate(CellPrebaf, content.transform);
            Cell.GetComponent<InventorySlot>().AddItem(_items[i]);
        }

    }
    public void RemoveItemFromChest(Item item)
    {
        _chest.Items.Remove(item);
    }
    public void UnRender()
    {
        for (int i = 0; i < content.childCount; i++)
        {
            
            content.GetChild(i).GetComponent<InventorySlot>().DestroyItSelf();
        }
        items.Clear();
        
    }
    void Update()
    {
        
    }
}
