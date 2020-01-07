using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class BlueprintCell : MonoBehaviour,IPointerClickHandler,IPointerEnterHandler,IPointerExitHandler
{
    public TextMeshProUGUI Name;
    public Blueprint ItemForCraft;
    public Image Border;
    public Image Icon;
    public void SelectThis()
    {
        CraftSystem.instance.ShowInfoAboutItem(ItemForCraft);
        ShowIngrients();
    }
    public void AddItem(Blueprint item)
    {
        ItemForCraft = item;
        Icon.sprite = item.Icon;
        Name.text = item.Name;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        SelectThis();
    }

    private void ShowIngrients()
    {
        CraftSystem.instance.RenderIngridients(ItemForCraft);
    }

    public void ShowBorder()
    {
        Border.enabled = true;
    }
    public void TurnOffBorder()
    {
        Border.enabled = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ShowBorder();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TurnOffBorder();
    }
}
