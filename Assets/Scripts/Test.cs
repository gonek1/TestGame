using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Test : MonoBehaviour /* IPointerClickHandler*/
{
    public static Test instance;
    // Start is called before the first frame update
    List<int> vs = new List<int> { 1, 2, 3 };
    void Start()
    {
        //int x;
        //x=vs.IndexOf(4);
        //Debug.Log(x);
    }
    void Awake()
    {
        instance = this;
    }
    public void TEST()
    {
        //Debug.Log("Test!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //public void OnPointerClick(PointerEventData eventData)
    //{
    //    Debug.Log("Hello1");
    //    if (eventData.button == PointerEventData.InputButton.Right)
    //    {
    //        Debug.Log("Hello");
    //    }

    //}
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Chest")
            Debug.Log("Hello");
    }
}
