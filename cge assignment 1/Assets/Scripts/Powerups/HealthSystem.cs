using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] EnemyDamages EnemyDamageInfo;
    [SerializeField] ShieldSystem shield;
    [SerializeField] HealthUI healthBar;
    [SerializeField] private float max_health;
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
        else
        {
            if (increase)
            {
                health += change_amount;
            }
        }

        CheckHealthOverflow();

        //only updates the health value on the UI when the health gets changed.
        healthBar.UpdateDisplayedHealth(health);
    }

    public float GetHealth()
    {
        return health;
    }

    public void CheckHealthOverflow()
    {
        if (health > max_health)
        {
            health = max_health;
        }
    }

    public bool IsPlayerAlive()
    {
        if (health <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void Collidedwith(string tag_name)
    {
        if (tag_name == "hfrldProjectile")
        {
            UpdateHealth(false, EnemyDamageInfo.GetProjectileDamage("hfrld"));
        }
        else if (tag_name == "lfrhdProjectile")
        {
            UpdateHealth(false, EnemyDamageInfo.GetProjectileDamage("lfrhd"));
        }
        else if (tag_name == "bossProjectile")
        {
            UpdateHealth(false, EnemyDamageInfo.GetProjectileDamage("boss"));
        }
        else
        {
            Debug.Log("Tag error");
        }
    }
}
