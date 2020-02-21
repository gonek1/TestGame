using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.InputSystem;


public class Controller : MonoBehaviour
{
    private Actions Inputs;
    [Header("Способности")]
    [SerializeField] List<Skill> SkillsInInventory = new List<Skill>();
    public Skill[] ActiveSkills = new Skill[3];
    [SerializeField] GameObject[] Skills;
    [Space(10)]
    [Header("Характеристики перса")]
    [SerializeField] float _speed = 40f;
    [SerializeField] int _damage;
    [SerializeField] int _armor;
    [Space(10)]
    [Header("Другое")]
    [SerializeField] List<Transform> homeFirePlaces = new List<Transform>();
    int indexOfLastHomeFirePosiotion = 0;
    [SerializeField] GameObject GameOverPanel;
    [SerializeField] Text SoulsText;
    [SerializeField] float TimeBegoreRegenStamina = 1.5f;
    [SerializeField] int NeedStaminaToAttack = 25;
    public static Controller instance;
    public HealthDisplay healthDisplay;
    [Range(0, 2)] public float Radius;
    [SerializeField] Transform attackPlace;
    [SerializeField] Animator animator;
    [SerializeField] CharacterController2D controller2D;
    bool isOnLadder;
    bool canOpenInv = true;
    bool canMove = true;
    bool canAttack = true;
    private float horInp;
    private float verInp;
    private bool jump = false;
    bool isOpen = false;
    [SerializeField] Rigidbody2D rb;
    
    public bool canUseOther { get; set; }
    public float Speed { get => _speed; set => _speed = value; }
    public bool CanAttack { get => canAttack; set => canAttack = value; }
    public List<Transform> HomeFirePlaces { get => homeFirePlaces; set => homeFirePlaces = value; }
    public int IndexOfLastHomeFirePosiotion { get => indexOfLastHomeFirePosiotion; set => indexOfLastHomeFirePosiotion = value; }
    public float HorInp { get => horInp; set => horInp = value; }
    public float VerInp { get => verInp; set => verInp = value; }

    public HealthSystem system;
    ExpSystem expSystem;
    public PlayerEqupimentXar equpimentXar;
    public MoneySystem moneySystem;
    void OnEnable()
    {
        Inputs.Player.Enable();
        
        StopCoroutine(RegenStamina());
        StartCoroutine(RegenStamina());
    }
    private void OnDisable()
    {
        Inputs.Player.Disable();
    }
    void Start()
    {
        equpimentXar = new PlayerEqupimentXar(_damage,_armor);
        canUseOther = true;
        expSystem = GetComponent<ExpSystem>();
        system = new HealthSystem(150, 50, 100);
        system.TakeDamageEvent += TakeDamage;
        system.HealthDownToZero += System_HealthDownToZero;
        controller2D = GetComponent<CharacterController2D>();
        healthDisplay.Setup(system);
        animator = GetComponent<Animator>();
        moneySystem = new MoneySystem(0, SoulsText);
    }

    private void System_HealthDownToZero(object sender, System.EventArgs e)
    {
        animator.SetTrigger("death");
        SetMove(false);
        canOpenInv = false;
        BoxCollider2D bc = GetComponent<BoxCollider2D>();
        bc.enabled = false;
        rb.bodyType = RigidbodyType2D.Static;

    }
    public void Respawn()
    {
        BoxCollider2D bc = GetComponent<BoxCollider2D>();
        bc.enabled = true;
        rb.bodyType = RigidbodyType2D.Dynamic;
        this.gameObject.SetActive(true);
        system.FullHeal();
        FindClosethesHomeFire();
        animator.SetTrigger("awake");
        SetMove(true);
        canOpenInv = true;
    }
    public void DestroyPlayer()
    {
        
        GameOverPanel.SetActive(true);
        this.gameObject.SetActive(false);

    }
    public void FindClosethesHomeFire()
    {
        GameOverPanel.SetActive(false);
        transform.position = HomeFirePlaces[IndexOfLastHomeFirePosiotion].position;
    }

    private void TakeDamage(object sender, System.EventArgs e)
    {
        Inventory.instance.CloseInventory();
        animator.SetTrigger("damage");
    }

    void Awake()
    {
        Inputs = new Actions();
        instance = this;
        Inputs.Player.Jump.performed += _ => Jump();
        Inputs.Player.Attack.performed += _ => Attack();
        Inputs.Player.OpenInventory.performed += _ => OpenOrCloseInventory();
    }
    public void GiveDamagaToEnemy()
    {
        Collider2D[] enemys = Physics2D.OverlapCircleAll(new Vector2(attackPlace.position.x, attackPlace.position.y), Radius);
        foreach (var enemy in enemys)
        {

            if (enemy.gameObject.tag == "Enemy")
            {
                int damage = equpimentXar.totalDamage;
                Hits.AddHit(attackPlace.position, damage, Color.red, 1, 1);
                enemy.GetComponent<Health>().TakeDamage(damage);
            }
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
    public bool CanMove()
    {
        return canMove;
    }
    void Update()
    {
        var value = Inputs.Player.Move.ReadValue<Vector2>();
        // Debug.Log(value.y);
        HorInp = value.x * Time.fixedDeltaTime * Speed;
        VerInp = value.y * Time.fixedDeltaTime;
        TimeBegoreRegenStamina = Mathf.Clamp(TimeBegoreRegenStamina - Time.deltaTime, 0, TimeBegoreRegenStamina);
        animator.SetFloat("speed", Mathf.Abs(HorInp));
        animator.SetFloat("velocityY", rb.velocity.y);


        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (Skills[0].GetComponent<SkillSlot>().SkillIn != null)
            {

                Skills[0].GetComponent<SkillSlot>().Use();
            }
            else
            {
                Debug.Log("Нет скила в ячейке!");
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (Skills[1].GetComponent<SkillSlot>().SkillIn != null)
                Skills[1].GetComponent<SkillSlot>().Use();
            else
            {
                Debug.Log("Нет скила в ячейке!");
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (Skills[2].GetComponent<SkillSlot>().SkillIn != null)
                Skills[2].GetComponent<SkillSlot>().Use();
            else
            {
                Debug.Log("Нет скила в ячейке!");
            }
        }
    }

    private void OpenOrCloseInventory()
    {
        if (canOpenInv)
        {
            isOpen = !isOpen;
            if (isOpen)
            {
                Inventory.instance.OpenInventory(1);
            }
            else if (!isOpen)
            {
                Inventory.instance.CloseInventory();
            }
        }
    }

    private void Attack()
    {
        if (canMove && CanAttack)
        {
            if (system.GetStamina() > NeedStaminaToAttack)
            {
                animator.SetTrigger("attack");
                TimeBegoreRegenStamina = 1.5f;
            }
            else
            {
                Debug.Log("Нет сил для атаки");
            }

        }
    }

    private void Jump()
    {
        if (canMove)
        {
            animator.SetTrigger("jump");
            animator.SetBool("isGrounded", false);
            jump = true;
            if (isOnLadder)
            {
                StartCoroutine(IgnoreLadder());
            }

        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("ladder") && Inputs.Player.Jump.ReadValue<float>()>0)
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
    public void AddSkillToInvenory(Skill skill)
    {
        SkillsInInventory.Add(skill);
    }
    public void AddActiveSkill(int index, Skill skill)
    {
        Skills[index].transform.GetComponent<SkillSlot>().AddSkill(skill);
        ActiveSkills[index] = skill;
    }
    public void RemoveSkillFromInvenory(Skill skill)
    {
        SkillsInInventory.Remove(skill);
    }
    public List<Skill> ReturnSkills()
    {
        return SkillsInInventory;
    }

}
