using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
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
    [SerializeField] private float m_speedOnLadder = 10f;
    [SerializeField] private float m_JumpForce = 400f;                          
    [SerializeField] private float m_JumpForceOnLadder = 400f;
    [Range(0, 1)] [SerializeField] private float m_CrouchSpeed = .36f;          
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;  
    [SerializeField] private bool m_AirControl = false;                         
    [SerializeField] private LayerMask m_WhatIsGround;                          
    [SerializeField] private Transform m_GroundCheck;                           
    [SerializeField] private Transform m_CeilingCheck;                          
    [SerializeField] private Collider2D m_CrouchDisableCollider;
    [SerializeField] private bool m_Grounded;
    private bool isOnLadder;
    private bool canOpenInv = true;
    private bool canMove = true;
    private bool canAttack = true;
    private float horInp;
    private float verInp;
    private bool jump = false;
    bool isOpen = false;
    const float k_GroundedRadius = .2f;
    const float k_CeilingRadius = .2f;
    private Rigidbody2D m_Rigidbody2D;
    public bool m_FacingRight = true;
    private Vector3 m_Velocity = Vector3.zero;
    private int m_JumpCount = 2;
    public class BoolEvent : UnityEvent<bool> { }
    public BoolEvent OnCrouchEvent;
    private bool m_wasCrouching = false;
    public bool canUseOther { get; set; }
    public float Speed { get => _speed; set => _speed = value; }
    public bool CanAttack { get => canAttack; set => canAttack = value; }
    public List<Transform> HomeFirePlaces { get => homeFirePlaces; set => homeFirePlaces = value; }
    public int IndexOfLastHomeFirePosiotion { get => indexOfLastHomeFirePosiotion; set => indexOfLastHomeFirePosiotion = value; }
    public float HorInp { get => horInp; set => horInp = value; }
    public float VerInp { get => verInp; set => verInp = value; }
    public bool CanOpenInv { get => canOpenInv; set => canOpenInv = value; }

    public HealthSystem system;
    ExpSystem expSystem;
    public PlayerEqupimentXar equpimentXar;
    public MoneySystem moneySystem;

    #region Методы, которые пока не требуют доработок
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
        healthDisplay.Setup(system);
        animator = GetComponent<Animator>();
        moneySystem = new MoneySystem(0, SoulsText);
    }
    private void System_HealthDownToZero(object sender, System.EventArgs e)
    {
        animator.SetTrigger("death");
        SetMove(false);
        CanOpenInv = false;
        BoxCollider2D bc = GetComponent<BoxCollider2D>();
        bc.enabled = false;
        m_Rigidbody2D.bodyType = RigidbodyType2D.Static;

    }
    public void Respawn()
    {
        BoxCollider2D bc = GetComponent<BoxCollider2D>();
        bc.enabled = true;
        m_Rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        this.gameObject.SetActive(true);
        system.FullHeal();
        FindClosethesHomeFire();
        animator.SetTrigger("awake");
        SetMove(true);
        CanOpenInv = true;
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
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        Inputs = new Actions();
        instance = this;
        Inputs.Player.Jump.performed += _ => Jump();
        Inputs.Player.Attack.performed += _ => Attack();
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
    #endregion
    void Update()
    {
        var value = Inputs.Player.Move.ReadValue<Vector2>();
        // Debug.Log(value.y);
        HorInp = value.x * Time.fixedDeltaTime * Speed;
        VerInp = value.y * Time.fixedDeltaTime;
        TimeBegoreRegenStamina = Mathf.Clamp(TimeBegoreRegenStamina - Time.deltaTime, 0, TimeBegoreRegenStamina);
        animator.SetFloat("speed", Mathf.Abs(HorInp));
        animator.SetFloat("velocityY", m_Rigidbody2D.velocity.y);
        m_Grounded = false;
        jump = false;
        ChechGround();
        Move(HorInp, jump, isOnLadder, VerInp);
        
        //if (Input.GetKeyDown(KeyCode.Alpha1))
        //{
        //    if (Skills[0].GetComponent<SkillSlot>().SkillIn != null)
        //    {

        //        Skills[0].GetComponent<SkillSlot>().Use();
        //    }
        //    else
        //    {
        //        Debug.Log("Нет скила в ячейке!");
        //    }
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha2))
        //{
        //    if (Skills[1].GetComponent<SkillSlot>().SkillIn != null)
        //        Skills[1].GetComponent<SkillSlot>().Use();
        //    else
        //    {
        //        Debug.Log("Нет скила в ячейке!");
        //    }
        //}

        //if (Input.GetKeyDown(KeyCode.Alpha3))
        //{
        //    if (Skills[2].GetComponent<SkillSlot>().SkillIn != null)
        //        Skills[2].GetComponent<SkillSlot>().Use();
        //    else
        //    {
        //        Debug.Log("Нет скила в ячейке!");
        //    }
        //}
    }

    private void ChechGround()
    {
        RaycastHit2D hitGround = Physics2D.Raycast(m_GroundCheck.position, Vector2.down, k_GroundedRadius);
        if (hitGround.collider != null && hitGround.transform.gameObject.tag == "Ground")
        {
            m_Grounded = true;
            m_JumpCount = 1;
        }
        else
        {
            m_Grounded = false;
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
            if (m_JumpCount>0)
            {
                animator.SetTrigger("jump");
                animator.SetBool("isGrounded", false);
                m_Rigidbody2D.velocity = Vector2.up *m_JumpForce;
                m_JumpCount--;
                jump = true;
            }
            if (isOnLadder)
            {
                StartCoroutine(IgnoreLadder());
            }
        }
        //Debug.Log(m_JumpCount);
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("ladder") && Inputs.Player.Jump.ReadValue<float>()>0)
        {
            isOnLadder = true;
            m_Rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("ladder"))
        {
            isOnLadder = false;
            m_Rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        }
    }
    void FixedUpdate()
    {
        

    }
    #region Рабочий код
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
        CanOpenInv = inv;
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
    #endregion 
    public void Move(float move, bool jump, bool IsOnladder, float VerticalInput)
    {
        if (m_Grounded || m_AirControl && !IsOnladder)
        {
            Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
            m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

            if (move > 0 && !m_FacingRight)
            {
                Flip();
            }
            else if (move < 0 && m_FacingRight)
            {
                Flip();
            }
        }
        if (IsOnladder)
        {
            Vector3 targetVelocity = new Vector2(0, VerticalInput * m_speedOnLadder);
            m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
        }
        if (IsOnladder && jump)
        {
            m_Rigidbody2D.velocity = new Vector2(move * m_JumpForceOnLadder * Time.deltaTime, 10);
        }
    }
    private void Flip()
    {
        m_FacingRight = !m_FacingRight;
        transform.Rotate(0f, 180f, 0f);
    }

}
