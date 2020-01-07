using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IngridienrCell : MonoBehaviour
{
    public TextMeshProUGUI Name;
    public Image Border;
    public Image Icon;
    protected abstractItem Item;
   public void DestroyCell()
    {
        Destroy(this.gameObject);
    }
    public void AddItem(abstractItem item)
    {
        Item = item;
        Icon.sprite = item.Icon;
        Name.text = item.Name;
    }
    void Start()
    {
        
        
    }

    public void ShowBorder()
    {
        Border.enabled = true;
    }
    public void SetColor(Color borderColor)
    {
        Border.color = borderColor;
    }
}
