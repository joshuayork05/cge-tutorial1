using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class BossController : MonoBehaviour
{
    [SerializeField] TopDownCharacterController player;
    [SerializeField] EnemyAttack attack;

    NavMeshAgent agent;

    private bool first = true;

    enum EnemyStates
    { 
        Idle,
        Attack,
        Waiting
    }

    EnemyStates CurrentState;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        transform.rotation = Quaternion.identity;

        if (CurrentState == EnemyStates.Attack)
        {
            agent.SetDestination(player.transform.position);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (first)
            {
                CurrentState = EnemyStates.Attack;
                player.UpdateCameraSize(10);
            }

            first = false;

        }
    }

    public void EnterWaitingMode()
    {
        CurrentState = EnemyStates.Waiting;
    }

    public void ExitWaitingMode()
    {
        CurrentState = EnemyStates.Attack;
    }


}
