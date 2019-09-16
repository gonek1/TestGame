using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum TypeOfAction
{
    Use,
    PickUp
}
public class InfoManager : MonoBehaviour
{
    #region Singlton
    public static InfoManager instance;
    void Awake()
    {
        instance = this;
    }
    #endregion
    public GameObject NotPrebaf;
    public GameObject Content;
    public GameObject PanelInfo;
    public GameObject NotificationInfo;
    public Text ItemName;
    public Text NotificationText;
    
    void Start()
    {
        
    }
    public void ShowInfoPanel(Item item)
    {
        NotificationText.text = "Press E to pick Up";
        PanelInfo.SetActive(true);
        ItemName.text = item.Name;
    }
    public void ShowInfoPanel(TypeOfAction type, GameObject game)
    {
        PanelInfo.SetActive(true);
        if (type == TypeOfAction.Use)
            NotificationText.text = " Press E to Use " + game.gameObject.name;
    }
    public void CloseInfoPanel()
    {
        NotificationText.text = null;
        ItemName.text = null;
        PanelInfo.SetActive(false);
    }

    public void ShowNotification(Item item)
    {
        var cell =  Instantiate(NotPrebaf, Content.transform);
        cell.transform.GetChild(0).GetComponent<Text>().text = "You picked  " + item.Name;
        StartCoroutine(Notification(cell));
        
    }
    IEnumerator Notification(GameObject gameObject)
    {
        
        yield return new WaitForSeconds(2);
        Destroy(gameObject, 2);
        
    }


}
