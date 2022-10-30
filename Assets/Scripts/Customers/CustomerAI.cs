using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
public class CustomerAI : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private bool orderComplete;
    public GameObject barWaypoint;
    public GameObject leaveWaypoint;

    public enum States
    {
        Arriving,
        Waiting,
        Leaving
    };

    public States aiState;

    // Start is called before the first frame update
    void Start()
    {
        aiState = States.Arriving;
        navMeshAgent = GetComponent<NavMeshAgent>();
        orderComplete = true; //CHANGE THIS
        navMeshAgent.SetDestination(barWaypoint.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        switch (aiState) {

            case States.Arriving:
                if (navMeshAgent.pathPending == false && navMeshAgent.remainingDistance <= 1) 
                {
                    aiState = States.Waiting;
                    navMeshAgent.speed = 0;
                }
                break;
            
            case States.Waiting:
                if (orderComplete) {
                    aiState = States.Leaving;
                    navMeshAgent.SetDestination(leaveWaypoint.transform.position);
                    navMeshAgent.speed = 4;
                }
                break;
            
            default:
                break;
        }
    }
}
