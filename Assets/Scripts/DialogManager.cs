using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    Actions inputs;
    [SerializeField] GameObject DialogPanel;
    [SerializeField] Text Name;
    [SerializeField] Text DialogText;
    public static DialogManager instance;
    Queue<string> dialog = new Queue<string>();
    private void OnEnable()
    {
        inputs.DialogManager.Enable();
    }
    private void OnDisable()
    {
        inputs.DialogManager.Disable();
    }
    void Awake()
    {
        instance = this;
        inputs = new Actions();
        inputs.DialogManager.NextPhrase.performed += _ =>
        {
            ShowNextPhrase();
        };
    }
    public void ShowDialog( string[] Text, string NameNPS)
    {
        Controller.instance.SetMove(false);
        Controller.instance.SetOpenInv(false);
        Controller.instance.canUseOther = false;
        Controller.instance.CanAttack = false;
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
        }
        else
        {
            EndDialog();
        }
    }
    public void EndDialog()
    {
        DialogPanel.gameObject.SetActive(false);
        dialog.Clear();
        Name.text = null;
        Controller.instance.SetMove(true);
        Controller.instance.SetOpenInv(true);
        Controller.instance.canUseOther = true;
        Controller.instance.CanAttack = true;
    }

        

}
