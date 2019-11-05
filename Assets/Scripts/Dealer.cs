using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dealer : MonoBehaviour
{
    [SerializeField] List<Item> items = new List<Item>();
    [SerializeField] Transform content;
    [SerializeField] GameObject ShopPanel;
    [SerializeField] Text description;
    [SerializeField] Text ItemCost;
    TypeOfAction typeOfAction = TypeOfAction.Use;
    void Start()
    {
        Render();
    }

    void Update()
    {
        
    }
    void Render()
    {
        for (int i = 0; i < items.Count; i++)
        {
            content.GetChild(i).GetComponent<DealerCell>().AddItem(items[i]);
        }
    }
    public void OpenShop()
    {
        ShopPanel.SetActive(true);
        Controller.instance.SetMove(false);
        Controller.instance.SetOpenInv(false);
    }
    public void CloseShop()
    {
        ShopPanel.SetActive(false);
        Controller.instance.SetMove(true);
        Controller.instance.SetOpenInv(true);
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player")&& Input.GetKeyDown(KeyCode.E))
        {
            OpenShop();
            InfoManager.instance.CloseInfoPanel();
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            CloseShop();
            InfoManager.instance.CloseInfoPanel();
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            InfoManager.instance.ShowInfoPanel(typeOfAction, this.gameObject);
        }
    }
    
}
