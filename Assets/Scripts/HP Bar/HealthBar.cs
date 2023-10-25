using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public int healthValue = 100;
    public Image healthDisplayValue;

    public void AddHealth(int value)
    {
        healthValue += value;

        if(healthValue > 100)
        {
            healthValue = 100;
        }

        RefreshDisplayValue();
    }

    public void SubtractHealth(int value)
    {
        healthValue -= value;

        if (healthValue <= 0)
        {
            healthValue = 0;

            Death();
        }

        RefreshDisplayValue();
    }

    public void RefreshDisplayValue()
    {
        healthDisplayValue.fillAmount = healthValue / 100f;
    }

    public virtual void Death()
    {

    }
}