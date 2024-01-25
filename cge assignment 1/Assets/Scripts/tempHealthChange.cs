using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempHealthChange : MonoBehaviour
{
    [SerializeField] HealthSystem health;
    [SerializeField] private bool increaseHealth = false;
    [SerializeField] private float health_amount;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            health.UpdateHealth(increaseHealth, health_amount);
        }

    }
}
