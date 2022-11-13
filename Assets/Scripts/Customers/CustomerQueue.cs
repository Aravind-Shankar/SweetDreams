using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerQueue : MonoBehaviour
{
    public CustomerSO customerSO;
    public GameObject spawnPoint;

    [HideInInspector]
    public int finishedCustomers;

    private Queue<Customer> customerQueue;
    private GameObject customerPrefab;
    private Customer[] customers;
    private int ordersCompletedCounter = 0;
    private float loadTime;

    PauseMenuToggle menu;

    private void Awake() {
        menu = FindObjectOfType<PauseMenuToggle>();
    }

    // Start is called before the first frame update
    void Start()
    {
        loadTime = Time.time;

        customers = customerSO.customers;
        customerPrefab = customerSO.customerPrefab;

        customerQueue = new Queue<Customer>();
        for (int i = 0; i < customers.Length; i++)
        {
            Debug.Log(customers[i]);
            customerQueue.Enqueue(customers[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (customerQueue.Count > 0 && customerQueue.Peek().arrivalTime <= Time.time - loadTime) {
            Customer c = customerQueue.Dequeue();
            Debug.Log(c + " dequeued");
            c.Setup(Instantiate(customerPrefab, spawnPoint.transform.position, Quaternion.identity));
            //TODO: drink system
        }
        //TODO: when drink is finished, call that customer's UpdateOrder()
        // ex: customers.customers[0].UpdateOrder();

        if (finishedCustomers == customers.Length) {
            menu.Win();
        }
    }

    public void CompleteOrder()
    {
        if (ordersCompletedCounter <= 5)
        {
            customers[ordersCompletedCounter].UpdateOrder();
            MoneySystem.Instance.Money += 50;
            ordersCompletedCounter += 1;
        }
    }

}