using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldSystem : MonoBehaviour
{
    [SerializeField] private float shield_timer = 0;
    [SerializeField] private float shield_max_time = 15;
    [SerializeField] GameObject pf_shield;
    private bool shield_enabled = false;
    public TopDownCharacterController player_info;
    public GameObject shieldInstance;

    public void StartShieldTimer()
    {
        shield_enabled = true;
        shield_timer = shield_max_time;
        CreateShield();
    }

    private void CreateShield()
    {
        shieldInstance = Instantiate(pf_shield, player_info.transform.position, Quaternion.identity);
    }

    private void FixedUpdate()
    {
        if (shield_enabled == true)
        {
            shield_timer -= Time.deltaTime;
        }
    }

    public float GetShieldTime()
    {
        return shield_timer;
    }

    public bool IsShieldEnabled()
    {
        return shield_enabled;
    }

    public void EndShield()
    {
        shield_enabled = false;
        Destroy(shieldInstance);
    }
}
