using System.Collections;
using System.Collections.Generic;
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

    private float timer;

    private float playerdirection_x;
    private float playerdirection_y;

    Vector2 idle_direction;
    Vector2 no_direction;

    private void Start()
    {
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
                timer += 3;
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



}
