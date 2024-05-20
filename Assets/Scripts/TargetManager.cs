using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class TargetManager : MonoBehaviour
{
    protected AIDestinationSetter destinationSetter => GetComponent<AIDestinationSetter>();
    [SerializeField] protected float checkViewRadius = 8f;
    [SerializeField] protected float followViewRadius = 15f;
    [SerializeField] protected int pathLayerNumber = 10;
    [SerializeField] protected LayerMask targetLayer;
    [SerializeField] protected float startTimeBtwShots = 2f;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform firePoint;
    [SerializeField] float bulletForce = 20f;
    [SerializeField] LayerMask raycastLayers;
    protected float timeBtwShots = 0f;
    public Transform GetTarget()
    {
        return destinationSetter.target;
    }

    public void SetTarget(Transform newTarget)
    {
        if (newTarget != GetTarget())
        {
            destinationSetter.target = newTarget;
        }
    }

    public void RemoveTarget()
    {
        if (GetTarget() != null)
        {
            destinationSetter.target = null;
        }
    }

    protected void FindTarget()
    {

        Collider2D[] targets = Physics2D.OverlapCircleAll(transform.position, checkViewRadius, targetLayer);
        Collider2D newTarget = null;

        foreach (Collider2D target in targets)
        {
            RaycastHit2D[] targetRaycast = new RaycastHit2D[1];
            GetComponent<Collider2D>().Raycast(target.transform.position - transform.position, targetRaycast, float.MaxValue, targetLayer + raycastLayers);

            if (targetRaycast[0].collider != null)
            {
                if (targetRaycast[0].collider == target)
                {
                    newTarget = targetRaycast[0].collider;
                }
            }
        }

        if (newTarget != null)
        {
            SetTarget(newTarget.transform);
        }
    }

    protected void LookAtTarget()
    {
        float angle = 0;

        Vector3 relative = transform.InverseTransformPoint(GetTarget().position);
        angle = Mathf.Atan2(relative.x, relative.y) * Mathf.Rad2Deg;
        transform.Rotate(0, 0, -angle);
    }

    protected void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Bullet>().shooter = this.gameObject;
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);

        timeBtwShots = 0;
    }
}
