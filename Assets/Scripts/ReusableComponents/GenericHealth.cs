using UnityEngine;

public class GenericHealth : MonoBehaviour
{
    [Header("Health Values")]
    public FloatValue maxHealth;
    public float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        // For the player
        if(maxHealth.RuntimeValue == 0) { FullHeal(); }

        // For the enemies
        currentHealth = maxHealth.initialValue;
    }

    public virtual void Heal(float amountToHeal)
    {
        maxHealth.RuntimeValue += amountToHeal;
        if (maxHealth.RuntimeValue > maxHealth.initialValue)
        {
            maxHealth.RuntimeValue = maxHealth.initialValue;
        }
    }


    public virtual void FullHeal()
    {
        maxHealth.RuntimeValue = maxHealth.initialValue;
    }

    public virtual void Damage(float amountToDamage)
    {
        maxHealth.RuntimeValue -= amountToDamage;
        if(maxHealth.RuntimeValue <= 0)
        {
            maxHealth.RuntimeValue = 0;
            this.transform.parent.gameObject.SetActive(false);
        }
    }

    public virtual void InstantDeath()
    {
        Damage(maxHealth.initialValue);
    }
}
