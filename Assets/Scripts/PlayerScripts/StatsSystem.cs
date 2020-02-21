using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class StatsSystem : MonoBehaviour
{
    public event EventHandler OnTextChanged;
    private int _Strength;
    private int _Agility;
    private int _Int;
    [SerializeField] Text _MaxAttackDamage;
    [SerializeField] Text _LvlText;
    [SerializeField] Text _TotalArmor;
    [SerializeField] Text _StrengthText;
    [SerializeField] Text _AgilityText;
    [SerializeField] Text _IntText;
    [SerializeField] Text _FreeLvlPointsText;
    [SerializeField] Text _FreeSouls;
    [SerializeField] Text _MaxHpText;
    [SerializeField] Text _MaxManaText;
     ExpSystem expSystem;
     Controller controller;
    int _FreeLvlPoints = 0;


    public void SetupStats(int Strength, int Agility, int Int)
    {
        _Strength = Strength;
        _Agility = Agility;
        _Int = Int;
    }

    private void ExpSystem_OnLvlUp(object sender, EventArgs e)
    {
        _FreeLvlPoints++;
        _FreeLvlPointsText.text = _FreeLvlPoints.ToString();
    }
    public void IncreaseStrength()
    {
        if (_FreeLvlPoints <= 0)
        {
            Debug.Log("Недостаточно поинтов!");
            return;
        }
        else
        {
            _FreeLvlPoints--;
            _Strength++;
            controller.system.SetupHealth(10);            
            StatsSystem_OnTextChanged(this, EventArgs.Empty);
        }
    }
    public void IncreaseAgility()
    {
        if (_FreeLvlPoints <= 0)
        {
            Debug.Log("Недостаточно поинтов!");
            return;
        }
        else
        {
            _FreeLvlPoints--;
            _Agility++;
            controller.system.SetUpAgility(5);
            StatsSystem_OnTextChanged(this, EventArgs.Empty);
        }
    }
    public void IncreaseInt()
    {
        if (_FreeLvlPoints <=0)
        {
            Debug.Log("Недостаточно поинтов!");
            return;
        }
        else
        {
            _FreeLvlPoints--;
            _Int++;
            controller.system.SetupMana(5);
            StatsSystem_OnTextChanged(this, EventArgs.Empty);
        }
        
    }
    void Start()
    {
        expSystem = GetComponent<ExpSystem>();
        expSystem.OnLvlUp += ExpSystem_OnLvlUp;
        controller = GetComponent<Controller>();
        controller.equpimentXar.OnItemChanged += EqupimentXar_OnItemChanged;
        OnTextChanged += StatsSystem_OnTextChanged;
        SetupStats(2, 1, 2);
        StatsSystem_OnTextChanged(this,EventArgs.Empty);
    }

    private void EqupimentXar_OnItemChanged(object sender, EventArgs e)
    {
        _TotalArmor.text = controller.equpimentXar.totalArmor.ToString();
        _MaxAttackDamage.text = controller.equpimentXar.totalDamage.ToString();
    }

    private void StatsSystem_OnTextChanged(object sender, EventArgs e)
    {
        _LvlText.text = expSystem.currentlvl.ToString();
        _StrengthText.text =  _Strength.ToString();
        _AgilityText.text = _Agility.ToString();
        _IntText.text = _Int.ToString();
        _FreeLvlPointsText.text = _FreeLvlPoints.ToString();
        _FreeSouls.text = controller.moneySystem.ReturnSoulsCount().ToString();
        _MaxHpText.text = controller.system.GetMaxHealth().ToString();
    }
    public void Refresh()
    {
        _TotalArmor.text = controller.equpimentXar.totalArmor.ToString();
        _MaxAttackDamage.text = controller.equpimentXar.totalDamage.ToString();
        _LvlText.text = expSystem.currentlvl.ToString();
        _FreeLvlPointsText.text = _FreeLvlPoints.ToString();
        _FreeSouls.text = controller.moneySystem.ReturnSoulsCount().ToString();
        _MaxHpText.text = controller.system.GetMaxHealth().ToString();
    }
}
