using UnityEngine;

public class Boom : MonoBehaviour
{
    [SerializeField] private float dmg= 30f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        Enemy enemy = collision.GetComponent<Enemy>(); 
        if(collision.CompareTag("Player"))
        {
            player.TakeDmg(dmg);
        }      
        if(collision.CompareTag("Enemy"))
        {
            enemy.TakeDmg(dmg);
        }
    }
    public void DestroyBoom()
    {
        Destroy(gameObject);
    }
}
