using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FastItemAcces : MonoBehaviour
{
    public Color OutLineColor;
    [SerializeField] Transform items;
  
    void Start()
    {
        OutLineCell();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            ChangePosUP(); 
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        { 
            ChangePosDown();
        }
    }
    void ChangePosUP()
    {
        for (int i = 0; i < items.childCount; i++)
        {
          items.GetChild(i).SetSiblingIndex(i+1);
        }
        OutLineCell();
    }
    void ChangePosDown()//ITS WORK!
    {
        for (int i = 0; i < items.childCount; i++)
        {
          items.GetChild(i).SetSiblingIndex(i - 1);
        }
        OutLineCell();
    }
    void OutLineCell()
    {
        items.GetChild(0).GetComponent<Image>().color = OutLineColor;
        items.GetChild(1).GetComponent<Image>().color = new Color(0, 0, 0, 255);
        items.GetChild(2).GetComponent<Image>().color = OutLineColor;
    }
}
