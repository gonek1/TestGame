using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Controller : MonoBehaviour
{
    public static Controller instance;
    public HealthDisplay healthDisplay;
    [Range(0,2)]public float Radius;
    public Transform attackPlace;
    public GameObject InventoryUI;
    public GameObject ButtonsInventoryUI;
    public Animator animator;
    public CharacterController2D controller2D;
    float HorInp;
    bool jump = false;
    [Header("Характеристики перса")]
    [SerializeField] float _speed = 40f;
    [SerializeField] float _damage;

    public float Damage { get => _damage; set => _damage = value; }
    public float Speed { get => _speed; set => _speed = value; }
    public HealthSystem system;
    StatsSystem statsSystem;
    ExpSystem expSystem;

    void Start()
    {
        statsSystem = GetComponent<StatsSystem>();
        expSystem = GetComponent<ExpSystem>();
        system =new HealthSystem(100, 50);
        statsSystem.SetupStats(expSystem.currentlvl, 0, 2, 2, 2);
        healthDisplay.Setup(system);
        animator = GetComponent<Animator>();
    }
    void Awake()
    {
        instance = this;
    }
    public void GiveDamagaToEnemy()
    {
        Collider2D[] enemys = Physics2D.OverlapCircleAll(new Vector2(attackPlace.position.x, attackPlace.position.y), Radius);
        foreach (var enemy in enemys)
        {

            if (enemy.gameObject.tag =="Enemy")
            enemy.GetComponent<Health>().TakeDamage((int)Damage);
        }
        system.minusMana(10);        
    }
    


    void Update()
    {   if (Input.GetKeyDown(KeyCode.Tab))
        {
            InventoryUI.SetActive ( !InventoryUI.activeSelf);
            ButtonsInventoryUI.SetActive(!ButtonsInventoryUI.activeSelf);
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
