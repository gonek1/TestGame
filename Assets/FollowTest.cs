using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTest : MonoBehaviour
{
    Vector2 mousePos;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Inventory.instance.IsOpen())
        {
            mousePos = Input.mousePosition;
            transform.position = mousePos;
        }
    }
}
