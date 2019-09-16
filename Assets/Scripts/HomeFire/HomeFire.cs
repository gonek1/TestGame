using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeFire : MonoBehaviour
{
    bool _IsPlayerNear = false;
    [SerializeField] TypeOfAction type = TypeOfAction.Use;
    private Controller controller;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)&& _IsPlayerNear)
        {
            Use();
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        controller = col.gameObject.GetComponent<Controller>();
        _IsPlayerNear = true;
        InfoManager.instance.ShowInfoPanel(type,this.gameObject);
    }
    void OnTriggerExit2D(Collider2D col)
    {
        _IsPlayerNear = false;
        InfoManager.instance.CloseInfoPanel();
    }
    void Use()
    {
        
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 5);
        foreach (var item in colliders)
        {
            if (item.gameObject.CompareTag("Enemy"))
            {
                Debug.Log("Enemy is NEAR!");
                return;
            }
        }
        controller.system.FullHeal();
        InfoManager.instance.CloseInfoPanel();
    }
}
