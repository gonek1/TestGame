using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    
    [SerializeField] GameObject DialogPanel;
    [SerializeField] Text Name;
    [SerializeField] Text DialogText;
    public static DialogManager instance;
    Queue<string> dialog = new Queue<string>();
    void Awake()
    {
        instance = this;
    }
    public void ShowDialog( string[] Text, string NameNPS)
    {
        dialog.Clear();
        foreach (string sentences in Text)
        {
            dialog.Enqueue(sentences);
        }
        DialogPanel.gameObject.SetActive(true);
        ShowNextPhrase();
        Name.text = NameNPS;

    }
    public void ShowNextPhrase()
    {
        if (dialog.Count > 0)
        {
            DialogText.text = dialog.Dequeue();
            Controller.instance.SetMove(false);
            Controller.instance.SetOpenInv(false);
            Controller.instance.canUseOther = false;
            Controller.instance.CanAttack = false;
        }
        else
        {
            EndDialog();
        }
    }
    public void EndDialog()
    {
        Controller.instance.SetMove(true);
        Controller.instance.SetOpenInv(true);
        Controller.instance.canUseOther = true;
        Controller.instance.CanAttack = true;
        DialogPanel.gameObject.SetActive(false);
        dialog.Clear();
        Name.text = null;

    }

        

}
