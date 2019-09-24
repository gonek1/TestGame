using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dealer : MonoBehaviour
{
    [SerializeField] List<Item> items = new List<Item>();
    [SerializeField] Transform content;
    [SerializeField] GameObject CellPrefab;
    void Start()
    {
        Render();
    }

    void Update()
    {
        
    }
    void Render()
    {
        foreach (var item in items)
        {
           var cell =  Instantiate(CellPrefab, content);
            cell.GetComponent<DealerCell>().AddItem(item);
        }
    }
}
