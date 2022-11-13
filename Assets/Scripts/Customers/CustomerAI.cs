using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
public class CustomerAI : MonoBehaviour
{
    public TextMeshProUGUI orderText;
    public GameObject barWaypoint;
    public GameObject leaveWaypoint;

    [HideInInspector]
    public bool orderComplete = false;
    [HideInInspector]
    public Potion orderedPotion;
    [HideInInspector]
    public PotionPanel potionPanel;

    private NavMeshAgent navMeshAgent;
    private float triggerTime;
    private SusBar susBar;
    private CustomerQueue customerQueue;

    public enum States
    {
        Arriving,
        Waiting,
        Leaving
    };

    public States aiState;

    private void Awake() {
        susBar = FindObjectOfType<SusBar>();
        customerQueue = FindObjectOfType<CustomerQueue>();
    }

    // Start is called before the first frame update
    void Start()
    {
        aiState = States.Arriving;
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.SetDestination(barWaypoint.transform.position);

        if (potionPanel)
            potionPanel.Clear();
        triggerTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        switch (aiState) {

            case States.Arriving:
                orderText.text = "";
                if (navMeshAgent.pathPending == false && navMeshAgent.remainingDistance <= 1) 
                {
                    aiState = States.Waiting;
                    orderText.text = "Order: " + orderedPotion.name;

                    if (potionPanel)
                        potionPanel.SetPotion(orderedPotion);
                }
                break;
            
            case States.Waiting:
                if (orderComplete) {
                    aiState = States.Leaving;
                    navMeshAgent.SetDestination(leaveWaypoint.transform.position);
                    navMeshAgent.speed = 5;

                    // Remove sus for finishing order
                    susBar.RemoveSus(20.0f);

                    customerQueue.finishedCustomers++;
                    orderText.text = "";

                    if (potionPanel)
                        Destroy(potionPanel.gameObject);
                } else if (Time.time > triggerTime) {
                    triggerTime++;

                    if (navMeshAgent.remainingDistance <= 1) {
                        navMeshAgent.SetDestination(new Vector3(Random.Range(-1.5f, 7), 0.1f, Random.Range(9, 16)));
                        navMeshAgent.speed = 3f;
                    }

                    // Add sus every second the person is waiting
                    susBar.AddSus(0.5f);
                }
                break;
            
            default:
                break;
        }
    }

}
