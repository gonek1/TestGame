using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthDisplay : MonoBehaviour
{
    private HealthSystem HealthSystem;
    private EnemyHealthsystem _EnemyHealthsystem;
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
    [SerializeField] Image stamina;
    public void Setup(HealthSystem healthSystem)
    {
        this.HealthSystem = healthSystem;
        HealthSystem.OnHealthChanged += HealthSystem_OnHealthChanged;
        HealthSystem.OnManaChanged += HealthSystem_OnManaChanged;
        HealthSystem.HealthDownToZero += HealthSystem_HealthDownToZero;
        HealthSystem.OnStaminaChanged += HealthSystem_OnStaminaChanged;
    }

    private void HealthSystem_HealthDownToZero(object sender, System.EventArgs e)
    {
        Destroy(gameObject);
    }

    public void SetupForEnemy(EnemyHealthsystem enemy)
    {
        this._EnemyHealthsystem = enemy;
        _EnemyHealthsystem.EnemyHealthDownToZero += EnemyHealthSystem_HealthDownToZero;
        _EnemyHealthsystem.OnHealthChanged += _EnemyHealthsystem_OnHealthChanged;
    }

    private void _EnemyHealthsystem_OnHealthChanged(object sender, System.EventArgs e)
    {
        health.fillAmount = _EnemyHealthsystem.GetPercent();
    }

    private void HealthSystem_OnStaminaChanged(object sender, System.EventArgs e)
    {
        stamina.fillAmount = HealthSystem.GetPercentStamina();
    }

    private void EnemyHealthSystem_HealthDownToZero(object sender, System.EventArgs e)
    {
        Destroy(gameObject);
        Collider2D[] searchPlayer = Physics2D.OverlapCircleAll(transform.position, 15);
        foreach (var gameobject in searchPlayer)
        {

            if (gameobject.gameObject.CompareTag("Player"))
            {
                gameobject.GetComponent<ExpSystem>().GainExp(500);
                gameobject.GetComponent<Controller>().system.PlusSouls(200);
                break;
            }
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
