using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyblePlatformScript : MonoBehaviour
{
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D col)
    {
       
        if (col.gameObject.CompareTag("Player"))
        {
            animator.SetTrigger("PlayerStep");
        }
    }
    public void DestroyItself()
    {
        Destroy(this.gameObject);
    }
}
