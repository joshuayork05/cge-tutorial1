using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject menu_panel;
    public GameObject settings_panel;
    public GameObject weapon_selector_panel;
    bool menu_panel_open = true;
    bool settings_panel_open = false;
    bool weapons_panel_open = false;

    public void LoadLevel1()
    {
        SceneManager.LoadScene(1);
    }

    public void ChangeMainPanelState()
    {
        menu_panel_open = !menu_panel_open;
        menu_panel.SetActive(menu_panel_open);
    }

    public void ChangeSettingsPanelState()
    {
        settings_panel_open = !settings_panel_open;
        settings_panel.SetActive(settings_panel_open);
    }

    public void ChangeWeaponsPanelState()
    {
        weapons_panel_open = !weapons_panel_open;
        weapon_selector_panel.SetActive(weapons_panel_open);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
