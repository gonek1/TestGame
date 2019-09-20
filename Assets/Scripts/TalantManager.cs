using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalantManager : MonoBehaviour
{
    #region Singlton
    public static TalantManager instance;
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
    [SerializeField] Transform parentOfInventorySlot;
    [SerializeField] Transform _Player;
    [SerializeField] TalantSlot Talslot;
    [SerializeField] Transform content;
    [SerializeField] GameObject TalantPrefabSlot;
    Inventory inventory;

    public Transform Player { get => _Player; set => _Player = value; }

    void Start()
    {
        inventory = Inventory.instance;
    }
   
    public void QuipTalant(Talant _talant, int _index)
    {
        Talant oldTalant = null;
        inventory.RemoveItem(_index);
        parentOfInventorySlot.GetChild(_index).GetComponent<InventorySlot>().ClearSlot();
        if (Talslot._talant != null)
        {
            oldTalant = Talslot._talant;

            inventory.AddItem(oldTalant);
        }
        Talslot.AddQuip(_talant);
    }
    public void RemoveTalant(Talant talant)
    {
        inventory.AddItem(talant);
    }
    public void Render(Talant talant)
    {
        var cell = Instantiate(TalantPrefabSlot, content);
            cell.GetComponent<Image>().sprite = talant.Icon;
    }

} 
