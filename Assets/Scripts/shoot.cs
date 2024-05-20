using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    [SerializeField] float startTimeBtwShots = 1;
    float timeBtwShots = 0f;
    public float bulletForce = 20f;

    void Update()
    {
        if (timeBtwShots >= startTimeBtwShots)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                shooting();
                timeBtwShots = 0f;
            }
        }
        else
        {
            timeBtwShots += Time.deltaTime;
        }

    }
    void shooting()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Bullet>().shooter = this.gameObject;
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up* bulletForce, ForceMode2D.Impulse);
    }
}
