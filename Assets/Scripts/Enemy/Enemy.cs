using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    sleep,
    idle,
    walk,
    attack,
    stagger
}

public class Enemy : MonoBehaviour
{
    [Header("State Machine")]
    public EnemyState currentState;

    [Header("Enemy Stats")]
    //public FloatValue maxHealth;
    //public float health;
    public string enemyName;
    //public int baseAttack;
    public float moveSpeed;
    public Vector2 homePosition;

    

    // Start is called before the first frame update
    private void Awake()
    {
        //health = maxHealth.initialValue;
        homePosition = transform.position;
    }
    /*
    private void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            DeathEffect();
            this.gameObject.SetActive(false);
        }
    }
    */
    

    public void Knock(Rigidbody2D rgbd2d, float knockTime)
    {
        StartCoroutine(KnockCo(rgbd2d, knockTime));
    }

    private IEnumerator KnockCo(Rigidbody2D rgbd2d, float knockTime)
    {
        if (rgbd2d != null)
        {
            yield return new WaitForSeconds(knockTime);
            rgbd2d.velocity = Vector2.zero;
            rgbd2d.GetComponent<Enemy>().currentState = EnemyState.idle;
            rgbd2d.velocity = Vector2.zero;
        }
    }
    public void ChangeState(EnemyState newState)
    {
        if (currentState != newState)
        {
            currentState = newState;
        }
    }

    public virtual void ChangeAnim(Vector2 direction)
    {
        direction = direction.normalized;
        if (direction.x < 0)
        {
            transform.localScale = new Vector3(1, 1, 0);
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 0);
        }
    }
}
