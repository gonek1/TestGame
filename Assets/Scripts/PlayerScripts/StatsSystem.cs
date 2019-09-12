using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StatsSystem : MonoBehaviour
{

    [SerializeField] Text _lvl;
    [SerializeField] Text _Souls;
    [SerializeField] Text _Strength;
    [SerializeField] Text _Agility;
    [SerializeField] Text _Int;
    public void SetupStats(int lvl, int Souls, int Strength, int Agility, int Int)
    {
        _lvl.text = lvl.ToString();
        _Souls.text = Souls.ToString();
        _Strength.text = Strength.ToString();
        _Agility.text = Agility.ToString();
        _Int.text = Int.ToString();
    }
    
}
