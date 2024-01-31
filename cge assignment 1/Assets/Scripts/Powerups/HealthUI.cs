using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class HealthUI : MonoBehaviour
{
    public HealthSystem healthSystem;
    public TMPro.TextMeshProUGUI Health;

    private void Start()
    {
        Health.text = $"Health: {healthSystem.GetHealth()}";
    }

    public void UpdateDisplayedHealth(float ui_health)
    {
        Health.text = $"Health: {ui_health}";
    }

}
