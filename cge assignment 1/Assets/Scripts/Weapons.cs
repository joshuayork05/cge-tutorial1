using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    [SerializeField] private TopDownCharacterController player;
    [SerializeField] GameObject projectilePreFab;
    [SerializeField] Transform firepoint;
    [SerializeField] float projectile_speed;
    [SerializeField] float projectile_damage;
    [SerializeField] private float cooldown_length = 1f;
    [SerializeField] private float max_ammo = 10;
    [SerializeField] private float ammo;
    [SerializeField] private bool In_menu;
    private float reload_time = 2;

    private float timer;

    private float playerdirection_x;
    private float playerdirection_y;

    Vector2 idle_direction;
    Vector2 no_direction;

    private void Start()
    {
        RapidFireWeapon();
        ammo = max_ammo;
    }

    private void FixedUpdate()
    {
        timer -= Time.deltaTime;

        if (player.GetPlayerSpeed() > 0)
        {
            Vector2 idle_direction = player.GetPlayerDirection();
            playerdirection_x = idle_direction.x;
            playerdirection_y = idle_direction.y;
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }

    void Fire()
    {
        if (timer <= 0)
        {
            no_direction = new Vector2(0f, 0f);

            Vector2 player_direction = player.GetPlayerDirection();
           
            GameObject projectileToSpawn = Instantiate(projectilePreFab, firepoint.position, Quaternion.identity); //thing being spawned, location, rotation

            if (player_direction == no_direction)
            {
                projectileToSpawn.GetComponent<Rigidbody2D>().AddForce(new Vector2(playerdirection_x,playerdirection_y).normalized * projectile_speed, ForceMode2D.Impulse);
            }
            else
            {
                //ensures the projectile fired has a consistent speed
                projectileToSpawn.GetComponent<Rigidbody2D>().AddForce(player_direction.normalized * projectile_speed, ForceMode2D.Impulse);
            }

            ammo -= 1;
            timer = cooldown_length;

            if (ammo == 0)
            {
                Debug.Log("Reloading");
                timer += reload_time;
                ammo = max_ammo;
            }
        }
        else
        {
            //used mainly for debugging but I doubt it will be used.
            Debug.Log($"In cooldown!");
        }
    }

    public void UpdateFireRate(float amount)
    {
        cooldown_length -= amount;
    }

    public void updateProjectileDamage(float amount)
    {
        Debug.Log($"Current Damage Output: {projectile_damage}");
        projectile_damage += amount;
        Debug.Log($"Current Damage Output: {projectile_damage}");
    }

    public float GetProjectileDamage()
    {
        return projectile_damage;
    }

    public void BasicWeapon()
    {
        ammo = 15;
        max_ammo = 15;
        projectile_damage = 10;
        projectile_speed = 8;
        cooldown_length = 0.8f;
        reload_time = 2f;
    }

    public void RapidFireWeapon()
    {
        ammo = 30;
        max_ammo = 30;
        projectile_damage = 8;
        projectile_speed = 8;
        cooldown_length = 0.1f;
        reload_time = 5f;
    }

    public void SniperWeapon()
    {
        ammo = 5;
        max_ammo = 5;
        projectile_damage = 25;
        projectile_speed = 15;
        cooldown_length = 1.5f;
        reload_time = 2.5f;
    }


}
