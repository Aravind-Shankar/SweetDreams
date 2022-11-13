using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerQueue : MonoBehaviour
{
    public CustomerSO customerSO;
    public GameObject spawnPoint;
    [Header("Active Orders UI")]
    public RectTransform orderViewContent;
    public GameObject potionPanelPrefab;
    public Vector3 potionPanelScale = Vector3.one;

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
            customerQueue.Enqueue(customers[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (customerQueue.Count > 0 && customerQueue.Peek().arrivalTime <= Time.time - loadTime) {
            Customer customer = customerQueue.Dequeue();
            EventLog.LogInfo("New customer arriving!");

            GameObject potionPanelObject = null;
            if (orderViewContent && potionPanelPrefab)
            {
                potionPanelObject = Instantiate(potionPanelPrefab);
                potionPanelObject.transform.SetParent(orderViewContent.transform, false);
                potionPanelObject.transform.localScale = potionPanelScale;
            }

            customer.Setup(
                Instantiate(customerPrefab, spawnPoint.transform.position, Quaternion.identity),
                customerSO.potionSO, potionPanelObject
            );
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