using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPick : MonoBehaviour
{
    InfoManager infoManager;
    bool IsNear;
    public Item Item;
    void Start()
    {
        infoManager = InfoManager.instance;
    }
    public  void PickUp()
    {
        
        bool waspicked = Inventory.instance.AddItem(Item);
        if (waspicked)
            infoManager.ShowNotification(Item);
            Destroy(gameObject);
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
    void Update()
    {
        if (Input.GetKey(KeyCode.E) && IsNear)
        {
            
            PickUp();

        }
    }


}
