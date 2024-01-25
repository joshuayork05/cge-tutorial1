using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] ShieldSystem shield;
    [SerializeField] HealthUI healthBar;
    private float health = 100;
    
    public void UpdateHealth(bool increase, float change_amount)
    {
        if (shield.IsShieldEnabled() == false)
        {
            if (increase)
            {
                health += change_amount;
            }
            else
            {
                health -= change_amount;
            }
        }

        healthBar.UpdateDisplayedHealth(health);

    }

    public float GetHealth()
    {
        return health;
    }

}
