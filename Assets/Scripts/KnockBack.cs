using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    [SerializeField] private float thrust = 0f;
    [SerializeField] private float knockTime = 0f;
    [SerializeField] private string otherTag = null;

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag(otherTag) && other.isTrigger)
        {
            Rigidbody2D hit = other.GetComponentInParent<Rigidbody2D>();
            if (hit != null)
            {

                Vector2 difference = hit.transform.position - transform.position;
                difference = difference.normalized * thrust;
                hit.AddForce(difference, ForceMode2D.Impulse);

                if (other.gameObject.CompareTag("Enemy") && other.isTrigger)
                {
                    //hit.GetComponent<Enemy>().currentState = EnemyState.stagger;
                    other.GetComponentInParent<Enemy>().currentState = EnemyState.stagger;
                    other.GetComponentInParent<Enemy>().Knock(hit, knockTime);
                }
                if (other.gameObject.CompareTag("Player"))
                {
                    if (other.GetComponentInParent<PlayerController>().currentState != PlayerState.stagger)
                    {
                        //hit.GetComponent<PlayerController>().currentState = PlayerState.stagger;
                        other.GetComponentInParent<PlayerController>().currentState = PlayerState.stagger;
                        other.GetComponentInParent<PlayerController>().Knock(knockTime);
                    }
                    
                }
            }
        }

        


    }


}
