using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempHealthChange : MonoBehaviour
{
    [SerializeField] HealthSystem health;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            health.UpdateHealth(false, 20.0f);
        }

    }
}
