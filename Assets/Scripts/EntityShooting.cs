using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityShooting : MonoBehaviour
{
    [SerializeField] float startTimeBtwShots = 2f;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform firePoint;
    [SerializeField] float bulletForce = 20f;
    [SerializeField] int pathLayer = 10;
    float timeBtwShots = 0f;
    TargetManager targetManager => GetComponent<TargetManager>();

    // Update is called once per frame
    void LateUpdate()
    {
        if (timeBtwShots >= startTimeBtwShots)
        {
            if (targetManager.GetTarget() != null)
            {
                if (targetManager.GetTarget().gameObject.layer != pathLayer)
                {
                    GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                    bullet.GetComponent<Bullet>().shooter = this.gameObject;
                    Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                    rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);

                    timeBtwShots = 0;
                }         
            }
        }
        else
        {
            timeBtwShots += Time.deltaTime;
        }
        
    }
}
