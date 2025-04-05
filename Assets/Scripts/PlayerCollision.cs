using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("EnemyBullet"))
        {
            Player player = GetComponent<Player>();
            player.TakeDmg(10f);
        }
        else if (collision.CompareTag("End"))
        {
            Debug.Log("Win CM Game r!!!");
            Destroy(collision.gameObject);
        }
    }
}
