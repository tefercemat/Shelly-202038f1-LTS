using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : GenericHealth
{
    [Header("Death Management")]
    public GameObject deathEffect;
    private float deathEffectDelay = 0.6f;

    
    public override void Damage(float amountToDamage)
    {
        currentHealth -= amountToDamage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            DeathEffect();
            this.transform.parent.gameObject.SetActive(false);
        }
    }

    public void DeathEffect()
    {
        if (deathEffect != null)
        {
            GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(effect, deathEffectDelay);
        }
    }
}
