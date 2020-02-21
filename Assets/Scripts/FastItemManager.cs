using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FastItemManager : MonoBehaviour
{
    [SerializeField] QuipSlot[] Borders;
    
    [SerializeField] Image Border;
    public static FastItemManager instance;
    [SerializeField] Transform[] FastItemsInInventory;
    [SerializeField] Transform[] FastItemsInGame;
    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        RenderIcons();
    }
    void Update()
    {
        if (Inventory.instance.IsOpen())
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                DisableBorder();
            }
        }
    }
    public void RenderIcons()
    {
        for (int i = 0; i < FastItemsInInventory.Length; i++)
        {
            if (FastItemsInInventory[i].GetComponent<FastItemCell>().Item !=null)
            {
                FastItemsInGame[i].GetChild(0).GetComponent<Image>().enabled = true;
                FastItemsInGame[i].GetComponent<FastItemCell>()
                .AddItem(FastItemsInInventory[i].GetComponent<FastItemCell>().Item);
            }
            else
            {
                FastItemsInGame[i].GetChild(0).GetComponent<Image>().enabled = false;
            }
        }
    }
    public void OutLineBorder(abstractItem item)
    {
        if (item is Quipment)
        {
          Quipment quipment =  item as Quipment;
            for (int i = 0; i < Borders.Length; i++)
            {
                if (Borders[i].TypeOfQuipSlot.ToString() == quipment.TypeOfItem.ToString())
                {
                    Borders[i].ShowBorder();
                }
                else
                {
                    Borders[i].TurnOffBorder();
                }
            }
        } 
        else if ( item is Weapon)
        {
            Weapon quipment = item as Weapon;
            for (int i = 0; i < Borders.Length; i++)
            {
                if ((Borders[i].TypeOfQuipSlot == TypeOfQuipSlot.Weapon))
                {
                    Borders[i].ShowBorder();
                }
                else
                {
                    Borders[i].TurnOffBorder();
                }
            }
        }
        else if (item is Item)
        {
            Border.enabled = true;
        }
        //ToolTip.SetActive(true);
        //ToolTip.GetComponent<Image>().sprite = item.Icon;
        //this.Item = item;
    }
    public void DisableBorder()
    {
        
        for (int i = 0; i < Borders.Length; i++)
        {

            Borders[i].TurnOffBorder();
            
        }
        
        Border.enabled = false;
    }
}
