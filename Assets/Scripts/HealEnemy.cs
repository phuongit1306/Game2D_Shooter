using UnityEngine;

public class HealEnemy : Enemy
{
    [SerializeField] private float healValue = 15f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(player != null)
            {
                player.TakeDmg(enterDmg);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(player != null)
            {
                player.TakeDmg(stayDmg);
            }
        }
    }

    protected override void Die()
    {
        HealPlayer();
        base.Die();
    }

    private void HealPlayer()
    {
        if(player != null)
        {
            player.Heal(healValue);
        }
    }
}
