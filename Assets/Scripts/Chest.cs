using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    Controller controller;
    public RectTransform Chestinventory;
    public List<Item> Items;
    [SerializeField] bool isNear;
    ChestManager chestManager;
    void Start()
    {
        chestManager = ChestManager.instance;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
            controller = col.gameObject.GetComponent<Controller>();
            
            isNear = true;
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
            isNear = false;
            controller.SetMove(true);
            controller.SetOpenInv(true);
            chestManager.UnRender();
            CloseChest();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)&&isNear)
        {
            
            if (!Chestinventory.gameObject.activeSelf)
            {
                controller.SetMove(false);
                controller.SetOpenInv(false);
                OpenChest();
                chestManager.Render(Items,this);
            }
            else
            {
                CloseChest();
                chestManager.UnRender();
                controller.SetMove(true);
                controller.SetOpenInv(true);
            }
        }
    }
    void OpenChest()
    {
        Chestinventory.gameObject.SetActive(true);
    }
    void CloseChest()
    {
        Chestinventory.gameObject.SetActive(false);
    }
    public void DestroyItSelf()
    {
        Destroy(gameObject);
    }
}
