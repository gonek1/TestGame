using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{


    [SerializeField] float speedOnLadder = 6f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0f;

            if (col.gameObject.CompareTag("Player") && Input.GetKey(KeyCode.W)&&Controller.instance.CanMove())
            {

                col.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speedOnLadder);

            }
            else if (col.gameObject.CompareTag("Player") && Input.GetKey(KeyCode.S) && Controller.instance.CanMove())
            {
                col.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speedOnLadder);
            }
            else
            {
                col.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0 );
            }
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {

            col.gameObject.GetComponent<Rigidbody2D>().gravityScale = 3f;
        }
    }
}
