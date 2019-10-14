using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosionFlowerScript : MonoBehaviour
{
    Animator animator;
    [SerializeField] [Range(0, 15)] float radius;
    [SerializeField] Transform attackPlace;
    [SerializeField] LayerMask mask;
    [SerializeField] int Damage = 15;
    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(Attack());
    }
    public void GiveDamageToPlayer()
    {
        Collider2D playerSearch = Physics2D.OverlapCircle(attackPlace.position, radius, mask);
        if (playerSearch != null)
        {
            playerSearch.gameObject.GetComponent<Controller>().system.TakeDamage(Damage);
        }
    }
    IEnumerator Attack()
    {
        while (this.gameObject.activeSelf)
        {
            yield return new WaitForSeconds(5);
            //Debug.Log("Hello");
            animator.SetTrigger("Attack");
        }
    }
}
