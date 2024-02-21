using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private Weapons weapon;
    [SerializeField] private Disabler disabler;
    [SerializeField] private float health;
    [SerializeField] private float maxHealth;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerProjectiles"))
        {
            Destroy(collision.gameObject);
            health -= weapon.GetProjectileDamage();
            CheckHealth();
        }
    }

    private void CheckHealth()
    {
        if (health <= 0)
        {
            disabler.DisableObject();
        }
    }
}
