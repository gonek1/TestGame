using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackPack : MonoBehaviour
{
    private void OnEnable()
    {
        Inventory.instance.IsOpen = true;
    }
    private void OnDisable()
    {
        Inventory.instance.IsOpen = false;
    }
}
