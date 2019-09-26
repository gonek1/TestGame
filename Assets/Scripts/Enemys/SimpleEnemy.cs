using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : MonoBehaviour
{
    [SerializeField] int Damage = 15;
    [SerializeField] float speed = 1f;
    [Range(0, 2)] [SerializeField] float Radius;
    [SerializeField] bool isFoundedPlayer= true;
    [SerializeField] Transform pos;
    [SerializeField] LayerMask mask;
    [SerializeField] LayerMask maskforground;
    [SerializeField] Transform groundCheck;
    [SerializeField] Vector2 offset;
    Vector2 target;
    Rigidbody2D rb;
    Vector2 originPos;
    private bool m_FacingLeft;
    Animator animator;
    [SerializeField] Transform attackPlace;

    void Start()
    {
        animator = GetComponent<Animator>();
        originPos = transform.position; 
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Findtarget();
        MoveToPlayer();
    }
    void Findtarget()
    {
        RaycastHit2D hitLeft = Physics2D.Raycast(pos.position, Vector2.right,5,mask);
        RaycastHit2D hitRight = Physics2D.Raycast(pos.position, Vector2.left, 5, mask);


        if (hitLeft.collider != null && hitLeft.transform.gameObject.tag == "Player")
        {
            TurnToLeft();
            
           offset =new Vector2(-1,-1);
           target = hitLeft.transform.position;
           isFoundedPlayer = true;
            if (Vector2.Distance(transform.position, target) < 2)
            {
                Attack();
            }
        }
        else if (hitRight.collider != null && hitRight.transform.gameObject.tag == "Player")
        {
            TurnToRight();
            offset = new Vector2(1, -1);
            target = hitRight.transform.position;
            isFoundedPlayer = true;
            if (Vector2.Distance(transform.position, target) < 2)
            {
                Attack();
            }
        }
        else if (!hitLeft)
        {
            offset = new Vector2(0, -1);
            isFoundedPlayer = false;
            target = originPos;
        }
    }
    void CheckForFlip()
    {
        RaycastHit2D hit = Physics2D.Raycast(groundCheck.position, Vector2.down, 1, maskforground);
        if (hit.collider == false)
        {
            Debug.Log("Not see  ground!");
            if (m_FacingLeft)
            {
                Flip();
            }
        }
    }
    void MoveToPlayer()
    {
      rb.position = Vector2.MoveTowards(transform.position, new Vector2(target.x,originPos.y)+ offset,speed*Time.deltaTime);       
    }
    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingLeft = !m_FacingLeft;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    void Attack()
    {
        animator.SetTrigger("attack");
    }
    public void GiveDamagaToEnemy()
    {
        Collider2D[] enemys = Physics2D.OverlapCircleAll(new Vector2(attackPlace.position.x, attackPlace.position.y), Radius);
        foreach (var enemy in enemys)
        {

            if (enemy.gameObject.CompareTag("Player"))
                enemy.GetComponent<Controller>().system.TakeDamage((int)Damage);
        }
        
    }
    void TurnToRight()
    {
        Vector3 theScale = transform.localScale;
        theScale.x = 1;
        transform.localScale = theScale;
    }
    void TurnToLeft()
    {
        Vector3 theScale = transform.localScale;
        theScale.x = -1;
        transform.localScale = theScale;
    }
}   
