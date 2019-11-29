using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCdialog : MonoBehaviour
{
    public TypeOfAction action = TypeOfAction.Dialog;
    public Queue<string> qwe;
    public string Name;
    public string[] sentences;
    bool PlayerIsNear = false;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            InfoManager.instance.ShowInfoPanel(action);
            PlayerIsNear = true;
        }
    }
    void OnTriggerExit2D()
    {
        PlayerIsNear = false;
        InfoManager.instance.CloseInfoPanel();
        DialogManager.instance.EndDialog();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)&&PlayerIsNear)
        {
            DialogManager.instance.ShowDialog(sentences, Name);
            InfoManager.instance.CloseInfoPanel();
        }
    }
}
