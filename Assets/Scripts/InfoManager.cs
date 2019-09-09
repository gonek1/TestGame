using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        PanelInfo.SetActive(true);
        ItemName.text = item.Name;
    }
    public void CloseInfoPanel()
    {
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
