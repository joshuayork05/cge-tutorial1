using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; //navmesh class

public class SimpleNavmeshFollow : MonoBehaviour
{
    [SerializeField] private EnemyAttack attack;

    public Transform target;
    NavMeshAgent agent;

    enum enemyStates
    {
        Idle,
        Attack
    };

    enemyStates CurrentState;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        //locks the rotation of the enemy 
        transform.rotation = Quaternion.identity;

        if (CurrentState == enemyStates.Attack)
        {
            agent.SetDestination(target.position);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CurrentState = enemyStates.Attack;
            attack.UpdateAttackState("Attack");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CurrentState = enemyStates.Idle;
            attack.UpdateAttackState("Idle");
        }
    }
}
