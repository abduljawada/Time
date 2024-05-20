using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AssistantTargetManager : TargetManager
{
    private void Update()
    {
        if (GetTarget() != null)
        {
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
            FindTarget();
        }
        timeBtwShots += Time.deltaTime;
    }
}
