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
        if (customerQueue.TryCompleteOrder())
        {
            inventory.RemoveItem();
        }
    }
}
