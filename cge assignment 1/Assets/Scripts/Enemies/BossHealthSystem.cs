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

    private bool firsttime = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerProjectiles"))
        {
            Debug.Log(waiting);

            if (waiting == false)
            {
                Debug.LogError("damage");
                health -= weapon.GetProjectileDamage();  
            }

            Debug.LogWarning("No damage");

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
                attack.UpdateFireRate();
                boss.EnterWaitingMode();
                spawnEnemies.UpdatePhase(2);

                if (firsttime)
                {
                    spawnEnemies.ActivateEnemies();
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
                boss.UpdateMovementSpeed();
                boss.EnterWaitingMode();
                spawnEnemies.UpdatePhase(3);

                if (firsttime)
                {
                    spawnEnemies.ActivateEnemies();
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
                boss.UpdateMovementSpeed();
                boss.EnterWaitingMode();
                spawnEnemies.UpdatePhase(4);

                if (firsttime)
                {
                    spawnEnemies.ActivateEnemies();
                    firsttime = false;
                }

                if (spawnEnemies.CheckEnemyStates())
                {
                    phase3 = false;
                    phase4 = true;
                    waiting = false;
                    firsttime = true;
                    boss.ExitWaitingMode();
                }
            }
        }
        else if (health <= 0)
        {
            Destroy(gameObject);
        }
        
    }

}
