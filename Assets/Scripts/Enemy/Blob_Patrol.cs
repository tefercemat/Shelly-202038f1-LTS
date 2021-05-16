using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blob_Patrol : Blob
{
    public Transform[] path;
    public int currentPoint;
    public Transform currentGoal;
    public float roundingDistance;

    public override void CheckDistance()
    {
        // Chase Radius
        if ((Vector3.Distance(target.position, transform.position) <= chaseRadius) && (Vector3.Distance(target.position, transform.position) > attackRadius))
        {
            if (currentState == EnemyState.idle || currentState == EnemyState.walk && currentState != EnemyState.stagger)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.fixedDeltaTime);
                animator.SetBool("Pursuit", true);
                ChangeAnim(temp - transform.position);
                rgb2d.MovePosition(temp);
            }
        }
        // Sleep Raidus
        else if (Vector3.Distance(target.position, transform.position) > chaseRadius)
        {
            if(Vector3.Distance(transform.position, path[currentPoint].position) > roundingDistance)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, path[currentPoint].position, moveSpeed * Time.fixedDeltaTime);
                ChangeAnim(temp - transform.position);
                rgb2d.MovePosition(temp);
            } else
            {
                ChangeGoal();
            }
            
        }

    }

    private void ChangeGoal()
    {
        if(currentPoint == path.Length -1)
        {
            currentPoint = 0;
            currentGoal = path[0];
        } else
        {
            currentPoint++;
            currentGoal = path[currentPoint];
        }
    }

}
