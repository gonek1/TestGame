using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthDisplay : MonoBehaviour
{
    #region Singleton
    public static HealthDisplay instance;
    void Awake()
    {
       // Debug.Log("hello");
        instance = this;
    }
    #endregion
    public bool _IsFlashble = false;
    public Image health;
    [SerializeField] float _Max_Health = 100;
    [SerializeField] float _Current_Health;
    [SerializeField] float _currentProcent;

    public float Max_Health { get => _Max_Health; set => _Max_Health = value; }
    public float Current_Health { get => _Current_Health; set => _Current_Health = value; }
    public float CurrentProcent { get => _currentProcent; set => _currentProcent = value; }

    void Start()
    {
        Current_Health = Max_Health;
    }
    private void Update()
    {
        
    }
    public void test()
    {
        Debug.Log("test");
    }

    private void CountHealth()
    {
        
        health.fillAmount = (Current_Health / Max_Health);
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
    
    public void TakeDamage(int damage)
    {
        Current_Health -=  damage;
        CountHealth();
        CurrentProcent = (Current_Health / Max_Health) * 100;
        
        if (CurrentProcent <=30)
        {
            Debug.Log("Хп меньще 30%");
            _IsFlashble = true;
            StartCoroutine(Blink());
        }
        
        
    }
    public void Heal(int heal)
    {
        Current_Health = Mathf.Clamp(_Current_Health+ heal, 0, _Max_Health);
        CountHealth();
        CurrentProcent = (Current_Health / Max_Health) * 100;
        if (CurrentProcent >=20&& _IsFlashble)
        {
            Debug.Log("Хп больше 20%");
            StopCoroutine(Blink());
            _IsFlashble = false;
        }

        
    }
    
}
