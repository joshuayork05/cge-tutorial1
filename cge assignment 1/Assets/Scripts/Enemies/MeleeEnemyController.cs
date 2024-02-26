using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyController : MonoBehaviour
{
    [SerializeField] HealthSystem PlayerHealth;
    [SerializeField] Disabler disabler;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //the false means decrease the player's health by 30
            PlayerHealth.UpdateHealth(false, 30);
            disabler.DisableObject();
        }
    }
}
