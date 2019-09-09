using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{

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
            isNear = true;
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
            isNear = false;
            
            chestManager.UnRender();
        CloseChest();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)&&isNear)
        {
            
            if (!Chestinventory.gameObject.activeSelf)
            {
                //Debug.Log("Open");
                OpenChest();
                chestManager.Render(Items,this);
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
