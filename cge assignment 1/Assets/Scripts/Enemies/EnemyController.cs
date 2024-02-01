using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform player;
    public float enemy_speed;
    public float stopping_distance;

    enum EnemyStates
    {
        Idle,
        MoveToPlayer,
        Attack
    }

    EnemyStates enemy_states;



    void Start()
    {
        //this gets the player's position without having to get drag the player in
        player = FindObjectOfType<TopDownCharacterController>().transform;
        enemy_states = EnemyStates.Idle;
    }

    void Update()
    {
        if (enemy_states == EnemyStates.MoveToPlayer)
        {
            MoveTowardsPlayer();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        enemy_states = EnemyStates.MoveToPlayer;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        enemy_states = EnemyStates.Idle;
    }

    private void MoveTowardsPlayer()
    {
        if (Vector2.Distance(transform.position, player.position) >= stopping_distance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, enemy_speed * Time.deltaTime);
        }
    }
}
