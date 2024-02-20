using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealthSystem : MonoBehaviour
{
    [SerializeField] Weapons weapon;
    [SerializeField] float health;
    [SerializeField] float maxHealth;
    [SerializeField] BossController boss;
    [SerializeField] BossAttackSys spawnEnemies;
    [SerializeField] EnemyAttack attack;

    private bool phase1 = true;
    private bool phase2 = false;
    private bool phase3 = false;
    private bool phase4 = false;
    private bool waiting = false;

    Vector2 EnemySpawnPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerProjectiles"))
        {
            if (!waiting)
            {
                health -= weapon.GetProjectileDamage();
                CheckHealth();
            }

            Destroy(collision.gameObject);

        }
    }

    private void CheckHealth()
    {
        if (phase1)
        {
            if (health < (maxHealth * 0.75) && health > (maxHealth * 0.5))
            {
                phase1 = false;
                phase2 = true;
                waiting = true;
                attack.UpdateFireRate();
                boss.EnterWaitingMode();
                spawnEnemies.SpawnEnemy("hfld", SetSpawnPoint(10, 10));

            }
        }
        else if (phase2)
        {
            if (health < (maxHealth * 0.5) && health > (maxHealth * 0.25))
            {
                phase2 = false;
                phase3 = true;
            }
        }
        else if (phase3)
        {
            if ((health < (maxHealth * 0.25) && health > 0))
            {
                phase3 = false;
                phase4 = true;
            }
        }
        else if (health <= 0)
        {
            Destroy(gameObject);
        }
        
    }

    private Vector2 SetSpawnPoint(float x, float y)
    {
        return EnemySpawnPoint = new Vector2(x, y);
    }

}