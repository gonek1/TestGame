using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRegen : MonoBehaviour
{
    float amount =1;
    
 
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
           // Debug.Log("123");
            this.gameObject.GetComponent<HealthDisplay>().Heal((int)amount);
            yield return new WaitForSeconds(1f);
        }
    }
}
