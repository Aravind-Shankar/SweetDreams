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

    private Inventory inventory;
    private Queue<Customer> customerSpawnQueue;
    private Queue<CustomerAI> customerAIOrderQueue;
    private bool orderPending;
    private GameObject customerPrefab;
    private Customer[] customers;
    private float loadTime;

    PauseMenuToggle menu;

    private void Awake() {
        menu = FindObjectOfType<PauseMenuToggle>();
        inventory = FindObjectOfType<Inventory>();
    }

    // Start is called before the first frame update
    void Start()
    {
        loadTime = Time.time;

        customers = customerSO.customers;
        customerPrefab = customerSO.customerPrefab;

        customerSpawnQueue = new Queue<Customer>();
        for (int i = 0; i < customers.Length; i++)
        {
            customerSpawnQueue.Enqueue(customers[i]);
        }
        customerAIOrderQueue = new Queue<CustomerAI>();
        orderPending = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (customerSpawnQueue.Count > 0 && customerSpawnQueue.Peek().arrivalTime <= Time.time - loadTime) {
            Customer customer = customerSpawnQueue.Dequeue();
            SpawnCustomer(customer);
        }

        if (customerSpawnQueue.Count == 0 && customerAIOrderQueue.Count == 0 && !orderPending) {
            // no new customers to spawn, no customers with active orders, no orders pending => won!
            menu.win = true;
        }
    }

    private void SpawnCustomer(Customer customer)
    {
        EventLog.LogInfo("New customer arriving!");

        GameObject potionPanelObject = null;
        if (orderViewContent && potionPanelPrefab)
        {
            potionPanelObject = Instantiate(potionPanelPrefab);
            potionPanelObject.transform.SetParent(orderViewContent.transform, false);
            potionPanelObject.transform.localScale = potionPanelScale;
        }

        GameObject customerObject = Instantiate(customerPrefab, spawnPoint.transform.position, Quaternion.identity);
        CustomerAI customerAI = customerObject.GetComponent<CustomerAI>();
        customerAI.orderedPotion = customerSO.potionSO.LookupPotionByName(customer.orderedPotionName);
        customerAI.potionPanel = potionPanelObject.GetComponent<PotionPanel>();

        orderPending = true;
    }

    private void UpdateCurrentOrder()
    {
        if (customerAIOrderQueue.Count == 0)
            return;

        customerAIOrderQueue.Peek().potionPanel.SetAsCurrent();
        orderPending = false;
    }

    public void AddActiveOrder(CustomerAI customerAI)
    {
        customerAIOrderQueue.Enqueue(customerAI);
        UpdateCurrentOrder();
    }

    public bool TryCompleteOrder()
    {
        if (customerAIOrderQueue.Count == 0)
        {
            EventLog.LogError("Can't deliver when there are no active orders!");
            return false;
        }

        if (inventory.GetItemType() != ItemType.validPotion)
        {
            EventLog.LogError("You don't have a potion in hand to deliver!");
            return false;
        }

        CustomerAI currentCustomerAI = customerAIOrderQueue.Peek();
        Potion orderedPotion = currentCustomerAI.orderedPotion;
        if (orderedPotion.IngredientsMatching(inventory.inHandIngredientFrequency))
        {
            currentCustomerAI.orderComplete = true;
            MoneySystem.Instance.Money += orderedPotion.sellingPrice;
            customerAIOrderQueue.Dequeue();
            UpdateCurrentOrder();
            EventLog.Log("Delivered the current order correctly!", Color.green);
            return true;
        }
        else
        {
            EventLog.LogError("Your potion and the ordered one don't match!");
            return false;
        }
    }

}