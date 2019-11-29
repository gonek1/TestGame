using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookScript : MonoBehaviour
{
    [SerializeField] float speed = 100f;
    Rigidbody2D rb;
    [SerializeField] bool findenemy = false;
    [SerializeField] const float TIMEBTWDESTROY = 2f;
    GameObject Player;
    GameObject target;
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
       // transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, -90, transform.rotation.w);
    }
    void Update()
    {
        if (!findenemy)
        {
            rb.velocity = transform.right * speed * Time.deltaTime;
        }
        else
        {
            Rigidbody2D rb = target.GetComponent<Rigidbody2D>();
            rb.bodyType = RigidbodyType2D.Kinematic;
            float step = 50 * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, step);
            if (Vector2.Distance(target.transform.position,Player.transform.position)<1)
            {
                target.transform.parent = null;
                Destroy(this.gameObject);
                rb.bodyType = RigidbodyType2D.Dynamic;
            }
                  
        }
       
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.gameObject.CompareTag("Enemy"))
        {
            target = col.gameObject;
            findenemy = true;
            target.transform.parent = this.transform;
        }
        else
        {
            Destroy(this.gameObject);
        }

    }

    
}
