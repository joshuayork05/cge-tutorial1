using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyController : MonoBehaviour
{
    [SerializeField] HealthSystem PlayerHealth;
    [SerializeField] private Weapons weapon;
    [SerializeField] private float health;
    [SerializeField] private float maxHealth;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth.UpdateHealth(false, 30);
            Destroy(gameObject);
        }
    }
}
