using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRegen : MonoBehaviour
{
    int amount =1;
    
 
   void OnEnable()
    {           
        StartCoroutine(Regen());
    }
    void OnDisable()
    {
        StopAllCoroutines();
    }
    IEnumerator Regen()
    {
        while (this.gameObject.activeSelf)
        {

            this.gameObject.GetComponent<Controller>().system.Heal(amount);
            yield return new WaitForSeconds(1f);
        }
    }
}
