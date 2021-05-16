using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealtReaction : MonoBehaviour
{

    public FloatValue playerHealth;
    public SignalSender healthSignal;

    public void Use(int amountToUse)
    {
        playerHealth.RuntimeValue += amountToUse;
        healthSignal.Raise();
    }
}
