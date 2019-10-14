using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class MoneySystem
{
    [SerializeField] Text SoulsCount;
    public EventHandler OnSoulsChanged;
    private int Souls;

    public int ReturnSoulsCount()
    {
        return Souls;
    }
    public MoneySystem(int soulsatstart, Text SoulsText)
    {
        Souls = soulsatstart;
        SoulsCount = SoulsText;
        OnSoulsChanged += UpDateTextUi;
        
    }
  
    void UpDateTextUi(object sender, System.EventArgs e)
    {
        SoulsCount.text = ReturnSoulsCount().ToString();
    }
    public void SpendSouls(int amount)
    {


        Souls = (int)Mathf.Clamp(Souls - amount, 0, Mathf.Infinity);
        OnSoulsChanged?.Invoke(this, EventArgs.Empty);


    }
    public void GetSouls(int amount)
    {
        Souls = (int)Mathf.Clamp(Souls + amount, 0, Mathf.Infinity);
        OnSoulsChanged?.Invoke(this, EventArgs.Empty);

    }
}
