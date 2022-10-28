using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderSubmitter : MonoBehaviour
{
    //public GameObject cupPrefab;
    private Inventory inventory;

    private void Awake()
    {
        inventory = FindObjectOfType<Inventory>();
    }

    public void SubmitOrder()
    {
        if (inventory.ContainsItem("Drink"))
        {
            ItemData drinkData = inventory.GetItem("Drink").GetComponent<ItemData>();
            if (drinkData.hasLiquid == true)
            {
                inventory.RemoveItem("Drink");
                Debug.Log("Submitted drink!");

            } else
            {
                Debug.Log("Can't submit an empty drink! The customer wouldn't like that");
            }
        } else
        {
            Debug.Log("You don't have a drink to submit!");
        }
    }
}
