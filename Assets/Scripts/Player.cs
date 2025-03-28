using System;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody2D rb;
    private SpriteRenderer flipPlayer;
    private Animator animator;
    [SerializeField] private float maxHp = 100f;
    private float currentHp;
    [SerializeField] private Image hpBar;




    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        flipPlayer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        currentHp = maxHp;
        UpdateHpBar();
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        Vector2 playerInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb.linearVelocity = playerInput.normalized * moveSpeed;

        if (playerInput.x < 0)
        {
            flipPlayer.flipX = true;
        }
        else if (playerInput.x > 0)
        {
            flipPlayer.flipX = false;
        }
        
        if(playerInput != Vector2.zero)
        {
            animator.SetBool("isRun", true);
        }
        else 
        {
            animator.SetBool("isRun", false);
        }
    }

    public void TakeDmg(float dmg)
    {
        currentHp -= dmg;
        currentHp = Math.Max(currentHp, 0);
        UpdateHpBar();
        if (currentHp <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    protected void UpdateHpBar()
    {
        if(hpBar != null)
        {
            hpBar.fillAmount = currentHp / maxHp;
        }
    }
}
