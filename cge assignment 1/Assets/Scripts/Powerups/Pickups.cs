using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    public GameObject pickup;

    [SerializeField] private ShieldSystem shieldSystem;
    [SerializeField] private HealthSystem healthSystem;
    [SerializeField] private float HealthBoostAmount;
    [SerializeField] private SpeedSystem speedSystem;
    [SerializeField] private TopDownCharacterController player;
    [SerializeField] private float FireRateChange;
    [SerializeField] private float DamageBoostAmount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (pickup.name == "Shield_pickup")
        {
            shieldSystem.StartShieldTimer();
        }
        else if (pickup.name == "Health_pickup")
        {
            healthSystem.UpdateHealth(true, HealthBoostAmount);
        }
        else if (pickup.name == "SpeedBoost_pickup")
        {
            speedSystem.StartSpeedTimer();
        }
        else if (pickup.name == "FireRate_Pickup")
        {
            player.UpdateFireRate(FireRateChange);
        }
        else if (pickup.name == "DamageBoost_Pickup")
        {
            player.updateProjectileDamage(DamageBoostAmount);
        }

        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }

    }
}