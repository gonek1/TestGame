using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    Controller controller;
    public List<abstractItem> Items;
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
        {
            isNear = false;
            Close();
        }
    }

    public void Close()
    {
        controller.SetMove(true);
        controller.SetOpenInv(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)&&isNear)
        {
            
            if (!chestManager.IsOpen())
            {
                controller.SetMove(false);
                controller.SetOpenInv(false);
                OpenChest();
            }
            else
            {
                controller.SetMove(true);
                controller.SetOpenInv(true);
            }
        }
    }
    void OpenChest()
    {
        chestManager.Render(Items, this);
        chestManager.OpenChest();
    }
    
    public void DestroyItSelf()
    {
        Close();
        Destroy(gameObject);
    }
}
