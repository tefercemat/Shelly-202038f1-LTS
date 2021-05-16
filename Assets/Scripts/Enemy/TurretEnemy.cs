using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretEnemy : Blob
{
    public GameObject projectile;
    public float fireDelay;
    private float fireDelaySeconds;
    private bool canFire = true;

    private void Update()
    {
        fireDelaySeconds -= Time.deltaTime;
        if(fireDelaySeconds <= 0)
        {
            canFire = true;
            fireDelaySeconds = fireDelay;
        }
    }

    public override void CheckDistance()
    {
        // Alert Radius
        if( (Vector3.Distance(target.position, transform.position) <= alertRadius) && attackArea.bounds.Contains(target.transform.position))
        {

            if (canFire)
            {
                Vector3 tempVector = target.transform.position - transform.position;
                GameObject current = Instantiate(projectile, transform.position, Quaternion.identity);
                current.GetComponent<RockProjectile>().Launch(tempVector.normalized);
                canFire = false;
            }
        }
        animator.SetBool("WakeUp", true);
        animator.SetBool("Pursuit", false);
    }

}
