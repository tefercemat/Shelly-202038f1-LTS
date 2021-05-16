using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blob_Blue : Enemy
{
    [Header("Enemy Details")]
    public Rigidbody2D enemyRigidbody;

    [Header("Enemy Radius")]
    public float alertRadius;
    public float chaseRadius;
    public float attackRadius;

    [Header("Enemy Attack")]
    public float attackDelay;
    private float attackDelaySeconds;
    private bool canAttack = true;
    public Collider2D attackArea;

    [Header("Attack - Dash")]
    public float dashSpeed;
    public float dashDuration;
    private float dashDurationSecond;

    [Header("Animator")]
    public Animator animator;

    [Header("Target")]
    public Transform target;


    private void Start()
    {
        animator = GetComponent<Animator>();
        enemyRigidbody = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        if(currentState == EnemyState.attack)
        {
            return;
        }
        attackDelaySeconds -= Time.deltaTime;
        if (attackDelaySeconds <= 0)
        {
            canAttack = true;
            attackDelaySeconds = attackDelay;
        }

        dashDurationSecond -= Time.deltaTime;
        if (dashDurationSecond <= 0)
        {
            dashDurationSecond = dashDuration;
        }

        CheckDistance();
    }

    public void CheckDistance()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if (attackArea.bounds.Contains(target.transform.position))
        {
            //Sleep
            if (distance > alertRadius)
            {
                animator.SetBool("Awake", false);
                ChangeState(EnemyState.sleep);
            }

            //Alert
            if (distance < alertRadius && distance > chaseRadius)
            {
                animator.SetBool("Awake", true);
                animator.SetBool("Walk", false);
                ChangeState(EnemyState.idle);
            }

            //Chase
            if (distance < chaseRadius && distance > attackRadius)
            {
                if (currentState == EnemyState.idle || currentState == EnemyState.walk && currentState != EnemyState.stagger)
                {
                    Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.fixedDeltaTime);
                    ChangeAnim(temp - transform.position);
                    enemyRigidbody.MovePosition(temp);
                    animator.SetBool("Walk", true);
                    ChangeState(EnemyState.walk);
                }
                    
            }

            //Attack
            if (distance < attackRadius)
            {
                if (canAttack && currentState == EnemyState.idle || currentState == EnemyState.walk && currentState != EnemyState.stagger)
                {
                    ChangeState(EnemyState.attack);
                    animator.SetBool("Walk", false);
                    AttackRoar();
                    canAttack = false;
                }
            }
        }
    }

    private void AttackRoar()
    {

        StartCoroutine("AttackCo");
    }

    private void AttackDash()
    {
        //StartCoroutine("AttackCo");
        Vector3 temp = Vector3.MoveTowards(transform.position, target.position, dashSpeed * Time.fixedDeltaTime);
        ChangeAnim(temp - transform.position);
        enemyRigidbody.MovePosition(temp);
    }


    private IEnumerator AttackCo()
    {
        animator.SetBool("AttackRoar", true);
        currentState = EnemyState.attack;
        yield return null;


        animator.SetBool("AttackRoar", false);
        yield return new WaitForSeconds(1f);
        currentState = EnemyState.idle;
    }


    

    


}
