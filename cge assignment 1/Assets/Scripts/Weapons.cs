using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    [SerializeField] GameObject projectilePreFab;
    [SerializeField] Transform firepoint;
    [SerializeField] float projectileSpeed;
    [SerializeField] float projectileDamage;
    [SerializeField] private float cooldownLength = 1f;
    [SerializeField] private float maxAmmo = 10;
    [SerializeField] private float ammo;

    private float timer;

    private void Start()
    {
        ammo = maxAmmo;
    }




}
