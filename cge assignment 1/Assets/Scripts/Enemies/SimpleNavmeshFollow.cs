using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; //navmesh class

public class SimpleNavmeshFollow : MonoBehaviour
{
    public Transform target;
    NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        agent.SetDestination(target.position);
    }
}
