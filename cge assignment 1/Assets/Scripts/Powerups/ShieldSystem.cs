using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShieldSystem : MonoBehaviour
{

    [SerializeField] GameObject pf_shield;
    [SerializeField] ShieldUI shieldUI;
    public TopDownCharacterController player_info;
    public GameObject shieldInstance;

    private bool shield_enabled = false;
    
    private float shield_timer = 0;
    private float shield_max_time = 10;
    public void StartShieldTimer()
    {
        shield_enabled = true;
        shield_timer = shield_max_time;
        CreateShield();
    }

    private void CreateShield()
    {
        shieldInstance = Instantiate(pf_shield, player_info.transform.position, Quaternion.identity);
        shieldUI.updateShieldBarState();
        shieldUI.ShieldTimerVisibility();
    }

    private void FixedUpdate()
    {
        if (shield_enabled == true)
        {
            shield_timer -= Time.deltaTime;
            shieldUI.UpdateShieldTimer(shield_timer);
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
        shieldUI.updateShieldBarState();
        shieldUI.ShieldTimerVisibility();
    }

    public void Update()
    {
        if (shield_enabled == true)
        {
            shieldInstance.transform.position = player_info.transform.position;
        }
    }
}
