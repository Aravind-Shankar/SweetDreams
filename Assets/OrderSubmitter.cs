using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderSubmitter : MonoBehaviour
{
    //public GameObject cupPrefab;
    private Inventory inventory;
    public ItemType itemSubmissionType;


    private void Awake()
    {
        inventory = FindObjectOfType<Inventory>();
    }

    public void SubmitOrder()
    {
        if (inventory.GetItemType() == itemSubmissionType)
        {
            inventory.RemoveItem();
            Debug.Log("Submitted Drink!");

        } else
        {
            Debug.Log("You don't have the right drink to submit!");
        }
    }
}
