using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class ShieldUI : MonoBehaviour
{
    [SerializeField] ShieldSystem shieldSystem;
    [SerializeField] GameObject Shield;
    [SerializeField] Image ShieldBar;

    private bool shieldBarActive = false;

    public void UpdateShieldTimer(float time_left)
    {
        if (shieldSystem.IsShieldEnabled())
        {
            ShieldBar.fillAmount = time_left / 15f;
        }
    }

    public void updateShieldBarState()
    {
        shieldBarActive = !shieldBarActive;
    }

    public void ShieldTimerVisibility()
    {
        Shield.SetActive(shieldBarActive);
    }
}
