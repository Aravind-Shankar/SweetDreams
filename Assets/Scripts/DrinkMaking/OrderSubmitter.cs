using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderSubmitter : MonoBehaviour
{
    //public GameObject cupPrefab;
    private Inventory inventory;
    public ItemType itemSubmissionType;

    private CustomerQueue customerQueue;

    private void Awake()
    {
        inventory = FindObjectOfType<Inventory>();
        customerQueue = FindObjectOfType<CustomerQueue>();
    }

    public void SubmitOrder()
    {
        if (inventory.GetItemType() == itemSubmissionType)
        {
            inventory.RemoveItem();
            EventLog.Log("Delivered the order correctly!", Color.green);
            customerQueue.CompleteOrder();
        }
        else
        {
            EventLog.LogError("You don't have the right potion to deliver!");
        }
    }
}
