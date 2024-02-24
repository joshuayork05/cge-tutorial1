using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHealthSystem : MonoBehaviour
{
    [SerializeField] Weapons weapon;
    [SerializeField] float health;
    [SerializeField] float maxHealth;
    [SerializeField] BossController boss;
    [SerializeField] BossAttackSys spawnEnemies;
    [SerializeField] EnemyAttack attack;
    [SerializeField] EnemyDamages enemyDamages;

    private bool phase1 = true;
    private bool phase2 = false;
    private bool phase3 = false;

    private bool waiting = false;

    private bool firsttime = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerProjectiles"))
        {
            if (waiting == false)
            {
                health -= weapon.GetProjectileDamage();  
            }

            CheckHealth();

            Destroy(collision.gameObject);

        }
    }

    private void CheckHealth()
    {
        if (phase1)
        {
            if (health < (maxHealth * 0.75) && health > (maxHealth * 0.5))
            {
                waiting = true;
                boss.EnterWaitingMode();
                spawnEnemies.UpdatePhase(2);

                if (firsttime)
                {
                    spawnEnemies.ActivateEnemies();
                    attack.UpdateFireRate();
                    firsttime = false;
                }

                if (spawnEnemies.CheckEnemyStates())
                {
                    phase1 = false;
                    phase2 = true;
                    waiting = false;
                    firsttime = true;
                    boss.ExitWaitingMode();
                } 

            }
        }
        else if (phase2)
        {
            if (health < (maxHealth * 0.5) && health > (maxHealth * 0.25))
            {
                waiting = true;
                boss.EnterWaitingMode();
                spawnEnemies.UpdatePhase(3);

                if (firsttime)
                {
                    spawnEnemies.ActivateEnemies();
                    boss.UpdateMovementSpeed();
                    firsttime = false;
                }

                if (spawnEnemies.CheckEnemyStates())
                {
                    phase2 = false;
                    phase3 = true;
                    waiting = false;
                    firsttime = true;
                    boss.ExitWaitingMode();
                }
            }
        }
        else if (phase3)
        {
            if ((health < (maxHealth * 0.25) && health > 0))
            {
                waiting = true;
                boss.EnterWaitingMode();
                spawnEnemies.UpdatePhase(4);

                //ensures enemies are only spawned once per phase
                if (firsttime)
                {
                    spawnEnemies.ActivateEnemies();
                    attack.UpdateProjectileDamage();
                    enemyDamages.UpdateBossDamage();
                    firsttime = false;
                }

                if (spawnEnemies.CheckEnemyStates())
                {
                    Debug.Log("End phase4");
                    phase3 = false;
                    waiting = false;
                    boss.ExitWaitingMode();
                }
            }
        }
        else if (health <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Victory");
        }
        
    }

}
