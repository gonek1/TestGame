using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthDisplay : MonoBehaviour
{
    private HealthSystem HealthSystem;
    #region Singleton
    public static HealthDisplay instance;
    void Awake()
    {
       // Debug.Log("hello");
        instance = this;
    }
    #endregion
    public bool _IsFlashble = false;
    [SerializeField] Image health;
    [SerializeField] Image mana;
    int x;
    void Start()
    {
        
    }
    public void Setup(HealthSystem healthSystem)
    {
        
        this.HealthSystem = healthSystem;
        HealthSystem.OnHealthChanged += HealthSystem_OnHealthChanged;
        HealthSystem.OnManaChanged += HealthSystem_OnManaChanged;
        HealthSystem.HealthDownToZero += HealthSystem_HealthDownToZero;
    }

    private void HealthSystem_HealthDownToZero(object sender, System.EventArgs e)
    {
        Destroy(gameObject);
        Collider2D[] enemys = Physics2D.OverlapCircleAll(transform.position, 15);
        foreach (var enemy in enemys)
        {

            if (enemy.gameObject.CompareTag("Player"))
                enemy.GetComponent<ExpSystem>().GainExp(500);
        }
    }

    private void HealthSystem_OnManaChanged(object sender, System.EventArgs e)
    {
        
        mana.fillAmount = HealthSystem.GetPercentMana();
    }

    private void HealthSystem_OnHealthChanged(object sender, System.EventArgs e)
    {
        health.fillAmount = HealthSystem.GetPercent();
       
    }

    

    IEnumerator Blink()
    {
        while (_IsFlashble)
        {
            
            yield return new WaitForSeconds(0.4f);
            health.color = Color.black;
            yield return new WaitForSeconds(0.4f);
            health.color = Color.red;
            
        }
        health.color = Color.red;
    }
    
     
   
    
    
}
