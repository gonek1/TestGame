using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CraftSystem : MonoBehaviour
{
    [SerializeField] Button CraftButton;
    [SerializeField] Image Icon;
    [SerializeField] TextMeshProUGUI des;
    [SerializeField] TextMeshProUGUI name;
    [SerializeField] Transform ContentOfItems;
    [SerializeField] Transform ContentOfIngridients;
    [SerializeField] GameObject ItemPrefab;
    [SerializeField] GameObject ListOfItems;
    [SerializeField] List<Blueprint> _blueprints;
    [SerializeField] Blueprint item;
    public static CraftSystem instance;
    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        for (int i = 0; i < _blueprints.Count; i++)
        {
           GameObject cell= Instantiate(ItemPrefab, ContentOfItems);
            cell.GetComponent<BlueprintCell>().AddItem(_blueprints[i]);
        }
    }
    void AddBlueprint(Blueprint blueprint)
    {
        _blueprints.Add(blueprint);
        Instantiate(ItemPrefab,ContentOfItems);
    }
    public void RenderIngridients(Blueprint blueprint)
    {
        int count = 0;
        item = blueprint;
        for (int i = 0; i < ContentOfIngridients.childCount; i++)
        {
            ContentOfIngridients.GetChild(i).GetComponent<IngridienrCell>().DestroyCell();
        }
        for (int i = 0; i < blueprint.ItemsNeedForCraft.Length; i++)
        {
            
            GameObject cell = Instantiate(ListOfItems, ContentOfIngridients);
            cell.GetComponent<IngridienrCell>().AddItem(blueprint.ItemsNeedForCraft[i]);
            cell.GetComponent<IngridienrCell>().ShowBorder();
            if (Inventory.instance.Items.Find(x => x == blueprint.ItemsNeedForCraft[i]))
            {
                cell.GetComponent<IngridienrCell>().SetColor(Color.green);
                count++;
            }
            else
            {
                cell.GetComponent<IngridienrCell>().SetColor(Color.red);
            }
        }
        if (count == blueprint.ItemsNeedForCraft.Length)
        {
            CraftButton.interactable = true;
        }
        else
        {
            CraftButton.interactable = false;
        }
    }
    public void ShowInfoAboutItem(Blueprint item)
    {
        des.text = item.Description;
        Icon.sprite = item.Icon;
        name.text = item.FinalItem.Name;
    }
    public void CraftItem()
    {
        for (int i = 0; i < item.ItemsNeedForCraft.Length; i++)
        {
            Inventory.instance.RemoveItem(item.ItemsNeedForCraft[i]);
        }
        Inventory.instance.AddItem(item.FinalItem);
        CraftButton.interactable = false;
    }


}
