using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    public GameObject pickup;
    [SerializeField] private ShieldSystem shieldSystem;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (pickup.name == "shield")
        {
            shieldSystem.StartShieldTimer();
        }

        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }

    }
}
