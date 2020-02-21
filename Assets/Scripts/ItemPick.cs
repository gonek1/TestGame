using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPick : MonoBehaviour
{
    Actions Inputs;
    InfoManager infoManager;
    bool IsNear;
    public abstractItem Item;
    void Start()
    {
        infoManager = InfoManager.instance;
    }
    public  void PickUp()
    {
        if (IsNear)
        {
            bool waspicked = Inventory.instance.AddItem(Item);
            if (waspicked)
                infoManager.ShowNotification(Item);
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag=="Player")
        {
            IsNear = true;
            infoManager.ShowInfoPanel(Item);
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            infoManager.CloseInfoPanel();
            IsNear = false;
        }
    }
    private void Awake()
    {
        Inputs = new Actions();
        Inputs.Items.TakeItem.performed += _ => PickUp();
    }
    private void OnEnable()
    {
        Inputs.Items.Enable();
    }
    private void OnDisable()
    {
        Inputs.Items.Disable();
    }



}
