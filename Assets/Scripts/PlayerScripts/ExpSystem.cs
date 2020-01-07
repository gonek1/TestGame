using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class ExpSystem : MonoBehaviour
{
    [SerializeField] Text CurrentExp;
    [SerializeField] Text CurrentExpNeed;
    public event EventHandler OnLvlUp;
    public event EventHandler OnXPGain;
    [SerializeField] Text LvlText;
    [SerializeField] Image icon;
    public int currentlvl = 0;
    public int currentExp = 0;
    List<int> lvlexpneed; 

    void Start()
    {
        OnXPGain += ExpSystem_OnXPGain;
        lvlexpneed = new List<int> { 50, 400 , 5000 , 20000, 70000, 100000 };
        LvlText.text = currentlvl.ToString();
        OnXPGain?.Invoke(this, EventArgs.Empty);
    }

    private void ExpSystem_OnXPGain(object sender, EventArgs e)
    {
        CurrentExp.text = currentExp.ToString();
        CurrentExpNeed.text = lvlexpneed[currentlvl].ToString();
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
        OnXPGain?.Invoke(this, EventArgs.Empty);
        icon.fillAmount = (float)currentExp / lvlexpneed[currentlvl];
    }
}
