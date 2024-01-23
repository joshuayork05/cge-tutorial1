using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    //creating a reference to the score system script
    public ScoreSystem scoreSystem;

    //creating a reference to the button's text/label for the button's text
    public TMPro.TextMeshProUGUI uiLabel;

    private void Update()
    {
        uiLabel.text = $"Score: {scoreSystem.GetScore()}";
    }
}
