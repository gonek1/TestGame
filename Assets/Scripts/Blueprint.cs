using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Blueprint", menuName = "Inventory/Blueprint")]
public class Blueprint : abstractItem
{
    public abstractItem FinalItem;
    public abstractItem[] ItemsNeedForCraft;
}
