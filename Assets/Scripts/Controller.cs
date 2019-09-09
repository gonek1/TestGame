using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Controller : MonoBehaviour
{
    [Range(0,2)]public float Radius;
    public Transform attackPlace;
    public GameObject InventoryUI;
    Animator animator;
    public CharacterController2D controller2D;
    float HorInp;
    bool jump = false;
    [Header("Характеристики перса")]
    [SerializeField] float _speed = 40f;
    [SerializeField] float _damage;

    public float Damage { get => _damage; set => _damage = value; }
    public float Speed { get => _speed; set => _speed = value; }

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void GiveDamagaToEnemy()
    {
        Collider2D[] enemys = Physics2D.OverlapCircleAll(new Vector2(attackPlace.position.x, attackPlace.position.y), Radius);
        foreach (var enemy in enemys)
        {
            if (enemy.GetComponent<Health>())
            enemy.GetComponent<Health>().TakeDamage((int)Damage);
        }
    }

    // Update is called once per frame
    void Update()
    {if (Input.GetKeyDown(KeyCode.Tab))
        {
            InventoryUI.SetActive ( !InventoryUI.activeSelf);
        }
        if (InventoryUI.activeSelf)
                 return;
        animator.SetFloat("speed", Mathf.Abs( HorInp));
        HorInp = Input.GetAxisRaw("Horizontal")* Speed * Time.fixedDeltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("jump");
            jump = true;
        }
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("attack");
        }

    }
    void FixedUpdate()
    {
        controller2D.Move(HorInp, false, jump);
        jump = false;
        
    }
    
    
    

}
