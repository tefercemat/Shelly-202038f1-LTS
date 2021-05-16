using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public FloatValue playerCurrentHealth;

    
    private void Start()
    {
        InitHealth();
    }

    private void InitHealth()
    {
        slider.maxValue = playerCurrentHealth.initialValue;
        slider.value = playerCurrentHealth.RuntimeValue;
    }
    
    public void setHealth()
    {
        slider.value = playerCurrentHealth.RuntimeValue;
    }
}
