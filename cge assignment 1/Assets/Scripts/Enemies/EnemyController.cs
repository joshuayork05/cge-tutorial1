using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private Weapons weapon;
    [SerializeField] private float health;
    [SerializeField] private float maxHealth;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.CompareTag("PlayerProjectiles")) //compare tag suddenly not accepted
        {
            Debug.Log(health);
            health -= weapon.GetProjectileDamage();
            Debug.Log(health);
        }
    }

}
