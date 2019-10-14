using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawScripts : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 10));
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.GetComponent<Controller>().system.TakeDamage(10);
            col.gameObject.GetComponent<Rigidbody2D>().velocity = -Vector2.right * Time.deltaTime * 10000;
        }
    }
}
