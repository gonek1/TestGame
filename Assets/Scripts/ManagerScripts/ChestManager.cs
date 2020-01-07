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
    [SerializeField] GameObject ChestPanelUI;
    public Transform content;
    public GameObject CellPrebaf;
    public List<abstractItem> items;
    private Chest _chest;

    void Start()
    {
        
    }

    public void Render(List<abstractItem> _items,Chest chest)
    {
        UnRender();
        _chest = chest;
        for (int i = 0; i < _items.Count; i++)
        {
            var Cell =  Instantiate(CellPrebaf, content.transform);
            Cell.GetComponent<ChestPrefab>().AddItem(_items[i]);
        }

    }
    public void RemoveItemFromChest(abstractItem item)
    {
        _chest.Items.Remove(item);
    }
    public void UnRender()
    {
        for (int i = 0; i < content.childCount; i++)
        {
            content.GetChild(i).GetComponent<ChestPrefab>().DestroyItem();
        }
        items.Clear();
    }
    public void OpenChest()
    {
        ChestPanelUI.SetActive(true);
    }
    public void CloseChest()
    {
        ChestPanelUI.SetActive(false);
        _chest.Close();
        
    }
    public bool IsOpen()
    {
        return ChestPanelUI.activeSelf;
    }
    public void TakeAllItems()
    {
        for (int i = 0; i < content.childCount; i++)
        {
            Inventory.instance.AddItem(content.GetChild(i).GetComponent<ChestPrefab>().item);
            RemoveItemFromChest(content.GetChild(i).GetComponent<ChestPrefab>().item);
            content.GetChild(i).GetComponent<ChestPrefab>().DestroyItem();

        }
        CloseChest();
        _chest.DestroyItSelf();
        _chest = null;
    }
}
