using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Controller : MonoBehaviour
{
    [SerializeField] float TimeBegoreRegenStamina = 3f;
    [SerializeField] int NeedStaminaToAttack = 25;
    public static Controller instance;
    public HealthDisplay healthDisplay;
    [Range(0,2)]public float Radius;
    public Transform attackPlace;
    public GameObject stats;
    public GameObject Invenotory;
    public GameObject[] InventoryUI;
    public Animator animator;
    public CharacterController2D controller2D;
    float HorInp;
    bool jump = false;
    [Header("Характеристики перса")]
    [SerializeField] float _speed = 40f;
    [SerializeField] float _damage;
    bool isOpen = false;

    public float Damage { get => _damage; set => _damage = value; }
    public float Speed { get => _speed; set => _speed = value; }
    public HealthSystem system;
    
    ExpSystem expSystem;

    void Start()
    {
        

        StartCoroutine(RegenStamina());
        expSystem = GetComponent<ExpSystem>();
        system =new HealthSystem(150, 50,100);
        
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
        system.minusStamina(NeedStaminaToAttack);        
    }
    IEnumerator RegenStamina()
    {

        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            if (TimeBegoreRegenStamina<=0)
            {
                system.PlusStamina(5);
            }
        }
            

    }
  
    void Update()
    {
        TimeBegoreRegenStamina -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isOpen = !isOpen;
            if (isOpen)
            {
                Invenotory.SetActive(true);
                stats.SetActive(false);
                foreach (var item in InventoryUI)
                {
                    item.SetActive(true);
                }
            }
            else if (!isOpen)
            {
                Invenotory.SetActive(false);
                stats.SetActive(false);
            } 
        }
        if (Invenotory.activeSelf)
        {
            return;
        }
            animator.SetFloat("speed", Mathf.Abs(HorInp));
            HorInp = Input.GetAxisRaw("Horizontal") * Speed * Time.fixedDeltaTime;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetTrigger("jump");
                jump = true;
            }
            if (Input.GetMouseButtonDown(0))
            {
             if (system.GetStamina()> NeedStaminaToAttack)
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
    void FixedUpdate()
    {

        controller2D.Move(HorInp, false, jump);
        jump = false;
        
    }
    
    
    

}
