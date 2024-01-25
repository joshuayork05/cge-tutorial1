using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject settings_panel;
    bool settings_panel_open = false;

    public void LoadLevel1()
    {
        SceneManager.LoadScene(1);
    }

    public void ChangeSettingsPanelState()
    {
        settings_panel_open = !settings_panel_open;
        settings_panel.SetActive(settings_panel_open);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
