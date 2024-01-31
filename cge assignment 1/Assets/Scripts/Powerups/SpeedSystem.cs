using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedSystem : MonoBehaviour
{
    [SerializeField] private TopDownCharacterController Player;
    [SerializeField] private float BoostAmount;
    [SerializeField] private float SpeedTimer;
    [SerializeField] private float SpeedMaxTime;

    private bool speed_enabled = false;

    public void StartSpeedTimer()
    {
        speed_enabled = true;
        SpeedTimer = SpeedMaxTime;
        Player.UpdatePlayerSpeed(BoostAmount);
    }

    private void FixedUpdate()
    {
        if (speed_enabled) 
        {
            SpeedTimer -= Time.deltaTime;
        }
    }

    public float GetSpeedTime()
    {
        return SpeedTimer;
    }

    public bool IsSpeedEnabled()
    {
        return speed_enabled;
    }

    public void EndSpeedTimer()
    {
        speed_enabled = false;
        SpeedTimer = 0;
        Player.UpdatePlayerSpeed(1);
    }
}
