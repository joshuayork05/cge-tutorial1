using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class HealthUI : MonoBehaviour
{
    [SerializeField] Image healthbar;

    public void UpdateDisplayedHealth(float health)
    {
        //divided by 100 so it fits the scale of 0-1
        healthbar.fillAmount = health / 100f;
    }

}
