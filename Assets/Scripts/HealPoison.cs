using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Quipment", menuName = "Inventory/Quipment")]
public class HeallPoison : Item
{
    
    [SerializeField] int numberOfHeal;
    public override void Use(int IndexSlot)
    {
        
        Debug.Log("ez");
        HealthDisplay.instance.Heal(numberOfHeal);
    }
    void Start()
    {
      
    }
    
}
