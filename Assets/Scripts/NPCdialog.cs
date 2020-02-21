using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCdialog : MonoBehaviour
{
    Actions Inputs;
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
        //var x = Inputs.NPC.StartDialog.ReadValue<float>();
    }

    private void StartDialog()
    {
        if (PlayerIsNear)
        {
            DialogManager.instance.ShowDialog(sentences, Name);
            InfoManager.instance.CloseInfoPanel();
        }
    }

    private void Awake()
    {
        Inputs = new Actions();
        Inputs.NPC.StartDialog.performed += _ => StartDialog();
    }
    private void OnEnable()
    {
        Inputs.NPC.Enable();
    }
    private void OnDisable()
    {
        Inputs.NPC.Disable();
    }
}
