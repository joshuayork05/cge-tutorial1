using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] GameObject pf_projectile;
    [SerializeField] Transform firepoint;
    [SerializeField] Transform target;
    [SerializeField] float cooldown;
    [SerializeField] private float attack_timer = 1f;
    [SerializeField] float projectile_speed;
    [SerializeField] float projectile_damage;

    private void Update()
    {
        attack_timer -= Time.deltaTime;

        if (attack_timer <= 0f)
        {
            Vector3 direction = target.transform.position - transform.position;
            GameObject projectileToSpawn = Instantiate(pf_projectile, firepoint.position, Quaternion.identity);

            projectileToSpawn.GetComponent<Rigidbody2D>().AddForce(new Vector2(direction.x, direction.y).normalized * projectile_speed, ForceMode2D.Impulse);


            attack_timer = cooldown;
        }
    }

    public float GetProjectileDamage()
    {
        return projectile_damage;
    }

}
