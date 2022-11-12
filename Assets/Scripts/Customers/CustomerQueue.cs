using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerQueue : MonoBehaviour
{
    public TextAsset jsonFile;
    private Queue<Customer> customerQueue;
    private Customers customers;
    public GameObject customerPrefab;
    public PlayerMoney playerMoney;
    public GameObject spawnPoint;

    private int ordersCompletedCounter = 0;
    public float loadTime;
    public int finishedCustomers;

    PauseMenuToggle menu;

    private void Awake() {
        menu = FindObjectOfType<PauseMenuToggle>();
    }

    // Start is called before the first frame update
    void Start()
    {
        loadTime = Time.time;

        customers = JsonUtility.FromJson<Customers>(jsonFile.text);
        customerQueue = new Queue<Customer>();
        for (int i = 0; i < customers.customers.Length; i++)
        {
            Debug.Log(customers.customers[i]);
            customerQueue.Enqueue(customers.customers[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (customerQueue.Count > 0 && customerQueue.Peek().time <= Time.time - loadTime) {
            Customer c = customerQueue.Dequeue();
            Debug.Log(c + " dequeued");
            c.customerObject = Instantiate(customerPrefab, spawnPoint.transform.position, Quaternion.identity);
            //TODO: drink system
        }
        //TODO: when drink is finished, call that customer's UpdateOrder()
        // ex: customers.customers[0].UpdateOrder();

        if (finishedCustomers == customers.customers.Length) {
            menu.Win();
        }
    }

    public void CompleteOrder()
    {
        if (ordersCompletedCounter <= 5)
        {
            customers.customers[ordersCompletedCounter].UpdateOrder();
            playerMoney.Money += 50;
            ordersCompletedCounter += 1;
        }
    }

}

[System.Serializable]
public class Customers {
    public Customer[] customers;
}

[System.Serializable]
public class Customer{

    public int time;
    public string name;
    public int orderid;
    public GameObject customerObject;
    public bool drinkDone;

    public void UpdateOrder()
    {
        customerObject.GetComponent<CustomerAI>().orderComplete = true;
    }

    public override string ToString() {
        return time.ToString() + ", " + name + ", " + orderid.ToString();
    }
}