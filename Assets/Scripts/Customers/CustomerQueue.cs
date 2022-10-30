using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerQueue : MonoBehaviour
{
    public TextAsset jsonFile;
    private Queue<Customer> customerQueue;
    private Customers customers;
    public GameObject customerPrefab;

    // Start is called before the first frame update
    void Start()
    {
        customers = JsonUtility.FromJson<Customers>(jsonFile.text);
        customerQueue = new Queue<Customer>();
        foreach (Customer customer in customers.customers)
        {
            Debug.Log(customer);
            customerQueue.Enqueue(customer);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (customerQueue.Count > 0 && customerQueue.Peek().time <= Time.time) {
            Customer c = customerQueue.Dequeue();
            Debug.Log(c + " dequeued");
            c.customerObject = Instantiate(customerPrefab, new Vector3(-10,1,29), Quaternion.identity);
        }
    }
}

[System.Serializable]
public class Customers {
    public Customer[] customers;
}

[System.Serializable]
public class Customer {

    public int time;
    public string name;
    public int orderid;
    public GameObject customerObject;

    public override string ToString() {
        return time.ToString() + ", " + name + ", " + orderid.ToString();
    }
}