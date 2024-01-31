using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class ShieldUI : MonoBehaviour
{
    [SerializeField] ShieldSystem shieldSystem;
    [SerializeField] TMPro.TextMeshProUGUI Shield;

    private bool shieldTextActive = false;

    private void Start()
    {
        Shield.enabled = false;
    }

    public void UpdateShieldTimer(float time_left)
    {
        if (shieldSystem.IsShieldEnabled())
        {
            Shield.text = $"Shield Time: {time_left}";
        }
    }

    public void updateShieldTextState()
    {
        shieldTextActive = !shieldTextActive;
    }

    public void ShieldTimerVisibility()
    {
        Shield.enabled = shieldTextActive;
    }
}
