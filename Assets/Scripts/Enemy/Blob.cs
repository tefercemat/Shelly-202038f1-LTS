using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blob : Enemy
{
    public Rigidbody2D rgb2d;

    [Header("Target Variables")]
    public Transform target;
    public float alertRadius;
    public float chaseRadius;
    public float attackRadius;

    [Header("Attack Area")]
    public Collider2D attackArea;

    [Header("Animator")]
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        currentState = EnemyState.sleep;
        rgb2d = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;
        animator.SetBool("WakeUp", true);
        animator.SetBool("Pursuit", true);
        ChangeState(EnemyState.idle);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckDistance();
    }

    public virtual void CheckDistance()
    {
        
        // Alert Radius
        if ((Vector3.Distance(target.position, transform.position) <= alertRadius) && (Vector3.Distance(target.position, transform.position) > chaseRadius) && (attackArea.bounds.Contains(target.transform.position)))
        {
            animator.SetBool("WakeUp", true);
            animator.SetBool("Pursuit", false);
            ChangeState(EnemyState.idle);
        }
        // Chase Radius
        else if ((Vector3.Distance(target.position, transform.position) <= chaseRadius) && (Vector3.Distance(target.position, transform.position) > attackRadius) && (attackArea.bounds.Contains(target.transform.position)))
        {
            if (currentState == EnemyState.idle || currentState == EnemyState.walk && currentState != EnemyState.stagger)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.fixedDeltaTime);
                animator.SetBool("Pursuit", true);
                ChangeAnim(temp - transform.position);
                rgb2d.MovePosition(temp);
                ChangeState(EnemyState.walk);
            }
        }
        // Sleep Raidus
        else if (Vector3.Distance(target.position, transform.position) > chaseRadius || (attackArea.bounds.Contains(target.transform.position)))
        {
            Vector2 tempv2 = new Vector2(transform.position.x, transform.position.y);
            if (tempv2 == homePosition)
            {
                animator.SetBool("Pursuit", false);
                animator.SetBool("WakeUp", false);
                ChangeState(EnemyState.sleep);
            } else
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, homePosition, moveSpeed * Time.fixedDeltaTime);
                animator.SetBool("Pursuit", true);
                ChangeAnim(temp - transform.position);
                rgb2d.MovePosition(temp);
                ChangeState(EnemyState.walk);
            }
        }
    }


    public override void ChangeAnim(Vector2 direction)
    {
        direction = direction.normalized;
        animator.SetFloat("Horizontal", direction.x);
        animator.SetFloat("Vertical", direction.y);
    }
}
