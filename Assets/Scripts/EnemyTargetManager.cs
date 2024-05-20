using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System;

public class EnemyTargetManager : TargetManager
{
    [SerializeField] GameObject player;

    private void Update()
    {
        if (GetTarget() != null)
        {
            if (GetTarget().gameObject != player)
            {
                FindPlayer();
            }
            if (GetTarget().gameObject.layer == pathLayerNumber)
            {
                FindTarget();
            }
            else if (Vector2.Distance(transform.position, GetTarget().position) > followViewRadius)
            {
                RemoveTarget();
            }
            else
            {
                LookAtTarget();
                if (timeBtwShots >= startTimeBtwShots)
                {
                    Shoot();
                }
            }
        }
        else
        {
            if (!FindPlayer())
            {
                FindTarget();
            }
        }
        timeBtwShots += Time.deltaTime;
    }

    private bool FindPlayer()
    {
        RaycastHit2D[] playerRaycast = new RaycastHit2D[1];
        GetComponent<Collider2D>().Raycast(player.transform.position - transform.position, playerRaycast);
        //Debug.DrawRay(transform.position, player.transform.position - transform.position);

        if (playerRaycast[0].collider != null)
        {
            if (playerRaycast[0].collider.gameObject == player && Vector2.Distance(transform.position, playerRaycast[0].transform.position) <= checkViewRadius)
            {
                SetTarget(player.transform);
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    //private void OnDrawGizmosSelected()
    //{
        //Gizmos.DrawWireSphere(transform.position, checkViewRadius);
    //}
}
