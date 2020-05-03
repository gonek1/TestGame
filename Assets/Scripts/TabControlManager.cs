using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabControlManager : MonoBehaviour
{ 
    int max, min;
    [SerializeField] Text _nextTab;
    [SerializeField] Text _prevTab;
    [SerializeField] Text _currTab;
    [SerializeField] Transform[] _tabs;
    private Actions inputs;
    int currentTab = 1;
    void Start()
    {
        //Debug.Log(gameObject.name);
        _tabs[1].gameObject.SetActive(true);
        min = 0;
        max = _tabs.Length - 1;
        _nextTab.text = _tabs[currentTab + 1].gameObject.name.ToString();
        _prevTab.text = _tabs[_tabs.Length-1].gameObject.name.ToString();
        _currTab.text = _tabs[currentTab].gameObject.name.ToString();
       
    }
    private void Awake()
    {
        inputs = new Actions();
        inputs.TabContorolManager.SwipeLeft.performed += _ => PreviousTab();
        inputs.TabContorolManager.SwipeRight.performed += _ => NextTab();
    }
    private void OnDisable()
    {
        inputs.TabContorolManager.Disable();

    }
    private void OnEnable()
    {
        inputs.TabContorolManager.Enable();
    }
    public void UpDateTabname(int index)
    {
        currentTab = index;
        if (currentTab == min)
        {
            _nextTab.text = _tabs[currentTab + 1].gameObject.name.ToString();
            _prevTab.text = _tabs[_tabs.Length - 1].gameObject.name.ToString();
        }
        else
        {
            if (currentTab == max)
            {
                _nextTab.text = _tabs[0].gameObject.name.ToString();
                _prevTab.text = _tabs[currentTab - 1].gameObject.name.ToString();
            }
            else
            {
                _nextTab.text = _tabs[currentTab + 1].gameObject.name.ToString();
                _prevTab.text = _tabs[currentTab - 1].gameObject.name.ToString();
            }

        }
        _currTab.text = _tabs[currentTab].gameObject.name.ToString();
    }
    public void NextTab()
    {
        if (Inventory.instance.IsOpen)
        {
            _tabs[currentTab].gameObject.SetActive(false);
            currentTab++;
            if (currentTab > max)
            {
                currentTab = min;
            }
            _tabs[currentTab].gameObject.SetActive(true);
            if (currentTab == min)
            {
                _nextTab.text = _tabs[currentTab + 1].gameObject.name.ToString();
                _prevTab.text = _tabs[_tabs.Length - 1].gameObject.name.ToString();
            }
            else
            {
                if (currentTab == max)
                {
                    _nextTab.text = _tabs[0].gameObject.name.ToString();
                    _prevTab.text = _tabs[currentTab - 1].gameObject.name.ToString();
                }
                else
                {
                    _nextTab.text = _tabs[currentTab + 1].gameObject.name.ToString();
                    _prevTab.text = _tabs[currentTab - 1].gameObject.name.ToString();
                }

            }
            _currTab.text = _tabs[currentTab].gameObject.name.ToString();
            FastItemManager.instance.DisableBorder();
        }
    }
    public void PreviousTab()
    {
        if (Inventory.instance.IsOpen)
        {
            _tabs[currentTab].gameObject.SetActive(false);
            currentTab--;
            if (currentTab < min)
            {
                currentTab = max;
            }
            _tabs[currentTab].gameObject.SetActive(true);
            if (currentTab == max)
            {
                _nextTab.text = _tabs[0].gameObject.name.ToString();
                _prevTab.text = _tabs[currentTab - 1].gameObject.name.ToString();
            }
            else
            {
                if (currentTab == min)
                {
                    _prevTab.text = _tabs[max].gameObject.name.ToString();
                    _nextTab.text = _tabs[currentTab + 1].gameObject.name.ToString();
                }
                else
                {
                    _prevTab.text = _tabs[currentTab - 1].gameObject.name.ToString();
                    _nextTab.text = _tabs[currentTab + 1].gameObject.name.ToString();
                }

            }
            _currTab.text = _tabs[currentTab].gameObject.name.ToString();
            FastItemManager.instance.DisableBorder();
        }
    }
}
