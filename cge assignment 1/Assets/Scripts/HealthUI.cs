using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class HealthBar : MonoBehaviour
{
    public HealthSystem healthSystem;
    public TMPro.TextMeshProUGUI Health;

    private void Start()
    {
        Health.text = $"Health: {healthSystem.GetHealth()}";
    }

    public void UpdateDisplayedHealth()
    {
        Health.text = $"Health: {healthSystem.GetHealth()}";
    }

}
