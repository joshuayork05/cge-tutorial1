using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamages : MonoBehaviour
{


    private float bossDamage = 8;

    public float GetProjectileDamage(string name)
    {
        if (name == "lfrhd")
        {
            return 8;
        }
        else if (name == "hfrld")
        {
            return 5;
        }
        else
        {
            return bossDamage;
        }
    }

    public void UpdateBossDamage()
    {
        bossDamage = 13;
    }
}
