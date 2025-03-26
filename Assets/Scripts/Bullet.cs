using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 30f;
    [SerializeField] private float timeDestroyBullet = 0.5f;

    [SerializeField] private float dmg = 20f;
    void Start()
    {
        Destroy(gameObject, timeDestroyBullet);
    }

    void Update()
    {
        MoveBullet();
    }

    void MoveBullet()
    {
        transform.Translate(Vector2.right * bulletSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            if(enemy != null)
            {
                enemy.TakeDmg(dmg);
            }
            Destroy(gameObject);
        }
    }
}
