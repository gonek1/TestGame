﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Controller : MonoBehaviour
{
    [SerializeField] bool isOnLadder;
    [SerializeField] bool canOpenInv = true;
    [SerializeField] bool canMove = true;
    public bool CanMove()
    {
        return canMove;
    }
    [SerializeField] int damage;
    [SerializeField] int armor;
    [SerializeField] float TimeBegoreRegenStamina = 3f;
    [SerializeField] int NeedStaminaToAttack = 25;
    public static Controller instance;
    public HealthDisplay healthDisplay;
    [Range(0, 2)] public float Radius;
    [SerializeField] Transform attackPlace;
    [SerializeField] GameObject stats;
    [SerializeField] GameObject Invenotory;
    [SerializeField] GameObject[] InventoryUI;
    [SerializeField] Animator animator;
    [SerializeField] CharacterController2D controller2D;
    private float HorInp;
    private float VerInp;
    private bool jump = false;
    [Header("Характеристики перса")]
    [SerializeField] float _speed = 40f;
    [SerializeField] float _damage;
    bool isOpen = false;
    [SerializeField] Rigidbody2D rb;
    public bool canUseOther { get; set; }
    public float Speed { get => _speed; set => _speed = value; }
    public HealthSystem system;
    ExpSystem expSystem;
    public PlayerEqupimentXar equpimentXar;
    void Start()
    {
       
        equpimentXar = new PlayerEqupimentXar(40, 1);
        canUseOther = true;
        StartCoroutine(RegenStamina());
        expSystem = GetComponent<ExpSystem>();
        system = new HealthSystem(150, 50, 100, 150);
        controller2D = GetComponent<CharacterController2D>();
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

            if (enemy.gameObject.tag == "Enemy")
                enemy.GetComponent<Health>().TakeDamage((int)equpimentXar.basicDamage);
        }
        system.minusStamina(NeedStaminaToAttack);
    }
    IEnumerator RegenStamina()
    {

        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            if (TimeBegoreRegenStamina <= 0)
            {
                system.PlusStamina(20);
            }
        }


    }

    void Update()
    {
        HorInp = Input.GetAxisRaw("Horizontal") * Speed * Time.fixedDeltaTime;
        VerInp = Input.GetAxisRaw("Vertical") * Time.fixedDeltaTime;
        TimeBegoreRegenStamina = Mathf.Clamp(TimeBegoreRegenStamina - Time.deltaTime, 0, TimeBegoreRegenStamina);
        if (Input.GetKeyDown(KeyCode.Tab) && canOpenInv)
        {
            isOpen = !isOpen;
            if (isOpen)
            {
                canUseOther = false;
                Invenotory.SetActive(true);
                stats.SetActive(false);
                foreach (var item in InventoryUI)
                {
                    item.SetActive(true);
                }
                SetMove(false);
            }
            else if (!isOpen)
            {
                canUseOther = true;
                Invenotory.SetActive(false);
                stats.SetActive(false);
                SetMove(true);
            }
        }
        animator.SetFloat("speed", Mathf.Abs(HorInp));
        animator.SetFloat("velocityY",rb.velocity.y);
        
        if (Input.GetKeyDown(KeyCode.Space)&&canMove)
        {
            animator.SetTrigger("jump");
            animator.SetBool("isGrounded", false);
            jump = true;
            if (isOnLadder)
            {
                StartCoroutine(IgnoreLadder());
            }
            
        }
        
        if (Input.GetMouseButtonDown(0) && canMove)
        {
            if (system.GetStamina() > NeedStaminaToAttack)
            {
                animator.SetTrigger("attack");
                TimeBegoreRegenStamina = 3f;
            }
            else
            {
                Debug.Log("Нет сил для атаки");
            }

        }
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("ladder") && Input.GetKey(KeyCode.Space))
        {
            
            isOnLadder = true;
            rb.bodyType = RigidbodyType2D.Kinematic;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("ladder"))
        {
            isOnLadder = false;
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }
    void FixedUpdate()
    {
        controller2D.Move(HorInp, false, jump,isOnLadder,VerInp);
        jump = false;

    }
    public void HasLended()
    {
        animator.SetBool("isGrounded",true);
    }
    public void Rest()
    {
        system.FullHeal();
    }
    public void SetMove(bool move)
    {
        canMove = move;
        if (canMove)
        {
            Speed = 40f;
        }
        else
        {
            Speed = 0;
        }
    }
    public void SetOpenInv(bool inv)
    {
        canOpenInv = inv;
    }
    
    IEnumerator IgnoreLadder()
    {
       
        Physics2D.IgnoreLayerCollision(8, 12,true);
        yield return new  WaitForSeconds(0.3f);
        Physics2D.IgnoreLayerCollision(8, 12, false);
        
    }

}
