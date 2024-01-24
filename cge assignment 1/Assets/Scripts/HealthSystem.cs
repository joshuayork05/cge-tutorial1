using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] ShieldSystem shield;
    private HealthBar healthBar;
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

        healthBar.UpdateDisplayedHealth();

    }

    public float GetHealth()
    {
        return health;
    }

}
