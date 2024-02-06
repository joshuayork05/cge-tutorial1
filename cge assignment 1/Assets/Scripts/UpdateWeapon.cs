using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateWeapon : MonoBehaviour
{
    [SerializeField] private Weapons weapon;

    public void BasicWeapon()
    {
        weapon.BasicWeapon();
        Debug.Log("Bacis");
    }

    public void RapidFireWeapon()
    {
        weapon.RapidFireWeapon();
        Debug.Log("Rapid");
    }

    public void SniperWeapon()
    {
        weapon.SniperWeapon();
        Debug.Log("Snipe");
    }
}
