using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabControlManager : MonoBehaviour
{ 
    int max, min;
    [SerializeField] Text _NextTab;
    [SerializeField] Text _PrevTab;
    [SerializeField] Text _CurrTab;
    [SerializeField] Transform[] _Tabs;
    int currentTab = 1;
    void Start()
    {
        _Tabs[1].gameObject.SetActive(true);
        min = 0;
        max = _Tabs.Length - 1;
        _NextTab.text = _Tabs[currentTab + 1].gameObject.name.ToString();
        _PrevTab.text = _Tabs[_Tabs.Length-1].gameObject.name.ToString();
        _CurrTab.text = _Tabs[currentTab].gameObject.name.ToString();
    }
    public void UpDateTabname(int index)
    {
        currentTab = index;
        if (currentTab == min)
        {
            _NextTab.text = _Tabs[currentTab + 1].gameObject.name.ToString();
            _PrevTab.text = _Tabs[_Tabs.Length - 1].gameObject.name.ToString();
        }
        else
        {
            if (currentTab == max)
            {
                _NextTab.text = _Tabs[0].gameObject.name.ToString();
                _PrevTab.text = _Tabs[currentTab - 1].gameObject.name.ToString();
            }
            else
            {
                _NextTab.text = _Tabs[currentTab + 1].gameObject.name.ToString();
                _PrevTab.text = _Tabs[currentTab - 1].gameObject.name.ToString();
            }

        }
        _CurrTab.text = _Tabs[currentTab].gameObject.name.ToString();
    }
    public void NextTab()
    {
        _Tabs[currentTab].gameObject.SetActive(false);
        currentTab++;
        if (currentTab > max)
        {
            currentTab = min;
        }
        _Tabs[currentTab].gameObject.SetActive(true);
        if (currentTab == min)
        {
            _NextTab.text = _Tabs[currentTab+1].gameObject.name.ToString();
            _PrevTab.text = _Tabs[_Tabs.Length-1].gameObject.name.ToString();
        }
        else
        {
            if (currentTab==max)
            {
                _NextTab.text = _Tabs[0].gameObject.name.ToString();
                _PrevTab.text = _Tabs[currentTab - 1].gameObject.name.ToString();
            }
            else
            {
                _NextTab.text = _Tabs[currentTab + 1].gameObject.name.ToString();
                _PrevTab.text = _Tabs[currentTab - 1].gameObject.name.ToString();
            }
            
        }
        _CurrTab.text = _Tabs[currentTab].gameObject.name.ToString();
        FastItemManager.instance.DisableBorder();
    }
    public void PreviousTab()
    {
        _Tabs[currentTab].gameObject.SetActive(false);
        currentTab--;
        if (currentTab<min)
        {
            currentTab = max;
        }
        _Tabs[currentTab].gameObject.SetActive(true);
        if (currentTab == max)
        {
            _NextTab.text = _Tabs[0].gameObject.name.ToString();
            _PrevTab.text = _Tabs[currentTab - 1].gameObject.name.ToString();
        }
        else
        {
            if (currentTab == min)
            {
                _PrevTab.text = _Tabs[max].gameObject.name.ToString();
                _NextTab.text = _Tabs[currentTab + 1].gameObject.name.ToString();
            }
            else
            {
                _PrevTab.text = _Tabs[currentTab - 1].gameObject.name.ToString();
                _NextTab.text = _Tabs[currentTab + 1].gameObject.name.ToString();
            }
           
        }
        _CurrTab.text = _Tabs[currentTab].gameObject.name.ToString();
        FastItemManager.instance.DisableBorder();
    }
}
