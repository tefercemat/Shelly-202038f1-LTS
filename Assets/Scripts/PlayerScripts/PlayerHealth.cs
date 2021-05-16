using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : GenericHealth
{
    [SerializeField] private SignalSender healthSignal = null;


    public override void Damage(float amountToDamage)
    {
        base.Damage(amountToDamage);
        //maxHealth.RuntimeValue = currentHealth;
        healthSignal.Raise();
    }

    public override void Heal(float amountToHeal)
    {
        base.Heal(amountToHeal);
        healthSignal.Raise();
    }
}
