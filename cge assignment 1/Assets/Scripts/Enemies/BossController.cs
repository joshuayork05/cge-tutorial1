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
    [SerializeField] MusicController music;

    NavMeshAgent agent;

    enum EnemyStates
    { 
        Idle,
        Attack,
        Waiting
    }

    EnemyStates CurrentState;

    //somethings only need to happen once and this ensures that
    private bool firsttime = true;

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
            if (firsttime)
            {
                music.StopMusic("underground");
                music.StartMusic("boss");
                CurrentState = EnemyStates.Attack;
                attack.UpdateAttackState("Attack");
                player.UpdateCameraSize(10);
                firsttime = false;
            }
            
        }
    }

    public void UpdateMovementSpeed()
    {
        agent.speed += 0.5f;
    }

    public void EnterWaitingMode()
    {
        CurrentState = EnemyStates.Waiting;
        attack.UpdateAttackState("Waiting");
    }

    public void ExitWaitingMode()
    {
        CurrentState = EnemyStates.Attack;
        attack.UpdateAttackState("Attack");
    }


}
