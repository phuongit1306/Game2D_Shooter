using UnityEngine;

public class BossEnemy : Enemy
{
    [SerializeField] private GameObject bulletPrefabs;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float speedNormalBullets = 20f;
    [SerializeField] private float speedCircleBullets = 10f;
    [SerializeField] private float hpValue = 100f;
    [SerializeField] private GameObject miniEnemy;
    [SerializeField] private float skillCooldown = 2f;
    [SerializeField] private GameObject endGamePrefabs;
    private float nextSkillTime = 0f;
    protected override void Update()
    {
        base.Update();
        if(Time.time >= nextSkillTime)
        {
            UseSkill();
        }
    }
    protected override void Die()
    {
        Instantiate(endGamePrefabs, transform.position, Quaternion.identity);
        base.Die();
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
        const int bulletCount = 12;
        float angleStep = 360f / bulletCount;
        for (int i =0; i<bulletCount;i++)
        {
            float angle = i * angleStep;
            Vector3 bulletDirection = new Vector3(Mathf.Cos(Mathf.Deg2Rad*angle), Mathf.Sin(Mathf.Deg2Rad*angle), 0);
            GameObject bullet = Instantiate(bulletPrefabs, transform.position, Quaternion.identity);
            EnemyBullet enemyBullet = bullet.AddComponent<EnemyBullet>();
            enemyBullet.SetMovementDirection(bulletDirection* speedCircleBullets);
        }
    }
    private void Heal(float hpAmount)
    {
        currentHp = Mathf.Min(currentHp + hpAmount, maxHp);
        UpdateHpBar();
    }
    private void CreateMiniEnemy()
    {
        Instantiate(miniEnemy, transform.position, Quaternion.identity);
    }
    private void TeleToPlayer()
    {
        if(player != null)
        {
            transform.position = player.transform.position;
        }
    }
    private void ChooseRandomSkill()
    {
        int randomSkill = Random.Range(0, 5);
        switch(randomSkill)
        {
            case 0:
                ShootNormalBullets();
                break;
            case 1:
                ShootCircleBullets();
                break;
            case 2:
                Heal(hpValue);
                break;

            case 3:
                CreateMiniEnemy();
                break;
            case 4:
                TeleToPlayer();
                break;
        }
    }
    private void UseSkill()
    {
        nextSkillTime = Time.time + skillCooldown;
        ChooseRandomSkill();
    }
}
