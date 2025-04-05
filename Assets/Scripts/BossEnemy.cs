using UnityEngine;

public class BossEnemy : Enemy
{
    [SerializeField] private GameObject bulletPrefabs;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float speedNormalBullets = 20f;
    protected override void Update()
    {
        base.Update();
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ShootNormalBullets();
        }
    }
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
    private void ShootNormalBullets()
    {
        if(player != null)
        {
            Vector3 directionToPlayer = player.transform.position-firePoint.position;
            directionToPlayer.Normalize();
            GameObject bullet = Instantiate(bulletPrefabs, firePoint.position,Quaternion.identity);
            EnemyBullet enemyBullet= bullet.AddComponent<EnemyBullet>();
            enemyBullet.SetMovementDirection(directionToPlayer * speedNormalBullets);

        }
    }
    private void ShootCircleBullets()
    {

    }
    private void Heal()
    {

    }
    private void CreateMiniEnemy()
    {

    }
    private void TeleToPlayer()
    {

    }
}
