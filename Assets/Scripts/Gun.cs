using UnityEngine;
using TMPro;

public class Gun : MonoBehaviour
{
    private float rotateOffset = 180f;
    [SerializeField] private Transform firePos;
    [SerializeField] private GameObject bulletPrfs;
    [SerializeField] private float shotDelaytime = 0.15f;
    private float nextShot;
    [SerializeField] private int maxAmmo = 30;
    public int currentAmmo;
    [SerializeField] private TextMeshProUGUI ammoText;
    void Start()
    {
        currentAmmo = maxAmmo;
        UpdateAmmoText();
    }

    void Update()
    {
        RotateGun();
        Shoot();
        ReloadBullet();
    }

    void RotateGun()
    {
        if (Input.mousePosition.x < 0 || Input.mousePosition.x > Screen.width || Input.mousePosition.y < 0 || Input.mousePosition.y > Screen.height)
        {
            return;
        }

        Vector3 displacement = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = Mathf.Atan2(displacement.y, displacement.x) * Mathf.Rad2Deg;
        transform.rotation =  Quaternion.Euler(0, 0, angle + rotateOffset);

        if (angle < -90 || angle > 90)
        {
            transform.localScale = new Vector3(1,1,1);
        }
        else  
        {
            transform.localScale = new Vector3(1,-1,1);
        }
    }

    void Shoot()
    {
        if (Input.GetMouseButtonDown(0) && currentAmmo > 0 && Time.time > nextShot)
        {
            nextShot = Time.time + shotDelaytime;
            Instantiate(bulletPrfs, firePos.position, firePos.rotation);
            currentAmmo--;
            UpdateAmmoText();
        }
    }
    void ReloadBullet()
    {
        if(Input.GetKeyDown(KeyCode.R) && currentAmmo < maxAmmo)
        {
            currentAmmo = maxAmmo;
            UpdateAmmoText();
        }
    }
    private void UpdateAmmoText()
    {
        if(ammoText != null)
        {
            if(currentAmmo > 0)
            {
                ammoText.text = currentAmmo.ToString();
            }
            else
            {
                ammoText.text = "Hết đạn";
            }
        }
    }
}
