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
        Debug.Log("OW");

        if (collision.gameObject.CompareTag("PlayerProjectiles"))
        {
            Debug.Log(health);
            health -= weapon.GetProjectileDamage();
            Debug.Log(health);
        }
    }
}
