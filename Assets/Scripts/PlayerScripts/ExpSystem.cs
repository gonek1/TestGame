using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class ExpSystem : MonoBehaviour
{
    public event EventHandler OnLvlUp;
    [SerializeField] Text LvlText;
    [SerializeField] Image icon;
    public int currentlvl = 0;
    public int currentExp = 0;
    List<int> lvlexpneed; 

    void Start()
    {
        lvlexpneed = new List<int> { 50, 200 , 500 , 1000, 2500, 10000 };
        LvlText.text = currentlvl.ToString();
    }
    public void LvlUp(int amount)
    {
        currentlvl += amount;
        LvlText.text = currentlvl.ToString();
    }
    public void GainExp(float amount)
    {
        currentExp += (int)amount;
        for (int i = 0; currentExp > lvlexpneed[currentlvl]; i++)
        {
            if (currentExp >= lvlexpneed[currentlvl])
            {
                currentExp -= lvlexpneed[currentlvl];
                LvlUp(1);
                OnLvlUp(this, EventArgs.Empty);
            }
        }
        
        icon.fillAmount = (float)currentExp / lvlexpneed[currentlvl];
    }
    void Update()
    {
        
    }
}
