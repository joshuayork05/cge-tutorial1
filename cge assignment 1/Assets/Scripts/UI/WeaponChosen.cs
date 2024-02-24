using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponChosen : MonoBehaviour
{
    private string weapon_name;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    public string GetWeaponChosen()
    {
        return weapon_name;
    }

    public void UpdateWeaponChoice(string weaponName)
    {
        weapon_name = weaponName;
    }

}
