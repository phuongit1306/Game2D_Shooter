using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public abstract class Enemy : MonoBehaviour
{

    [SerializeField] protected float enemyMoveSpeed = 3f;
    protected Player player;

    [SerializeField] protected float maxHp = 100f;
    protected float currentHp;

    [SerializeField] private Image hpBar;
    protected virtual void Start()
    {
        player = FindAnyObjectByType<Player>();
        currentHp = maxHp;
        UpdateHpBar();
    }

    protected virtual void Update()
    {
        MoveToPlayer();
    }
    protected void MoveToPlayer()
    {
        if(player != null)
        {
            transform.position=Vector2.MoveTowards(transform.position, player.transform.position, enemyMoveSpeed*Time.deltaTime);
            FlipEnemy();
        }
    }
    protected void FlipEnemy()
    {
        if(player != null)
        {
            transform.localScale = new Vector3(player.transform.position.x < transform.position.x ? -1 : 1, 1, 1);
        }
    }

    public virtual void TakeDmg(float dmg)
    {
        currentHp -= dmg;
        currentHp = Math.Max(currentHp, 0);
        UpdateHpBar();
        if (currentHp <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
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