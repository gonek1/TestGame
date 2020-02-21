using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuipManager : MonoBehaviour
{
    [SerializeField] QuipSlot[] slots;
    public static QuipManager instance;
    void Awake()
    {
        instance = this;
    }
    public void QuipItem(abstractItem item)
    {
        if (item is Weapon)
        {
            slots[5].AddQuip(item);
        }
        else if ( item is Quipment)
        {
            Quipment quipment = item as Quipment;
            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i].TypeOfQuipSlot.ToString() == quipment.TypeOfItem.ToString())
                {
                    slots[i].AddQuip(quipment);
                    break;
                }
            }
        }
        
    }
}
