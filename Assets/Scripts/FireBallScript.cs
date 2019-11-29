using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallScript : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] float Radius= 1;
    [SerializeField] int damage= 50;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D[] enemys = Physics2D.OverlapCircleAll(transform.position, Radius);
        foreach (var enemy in enemys)
        {

            if (enemy.gameObject.tag == "Enemy")
            {
                enemy.GetComponent<Health>().TakeDamage(damage);
                Hits.AddHit(enemy.transform.position, damage, Color.red, 1, 1);
            }
        }
        Destroy(this.gameObject);
    }
    private void Update()
    {
        transform.position += transform.right* speed*Time.deltaTime;
    }
   

}
