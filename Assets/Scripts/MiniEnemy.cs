using UnityEngine;

public class MiniEnemy : Enemy
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            player.TakeDmg(enterDmg);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            player.TakeDmg(stayDmg);
        }
    }
}
