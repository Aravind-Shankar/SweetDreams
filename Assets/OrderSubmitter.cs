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
                inventory.DestroyItem("Drink");
                
            }
        }
    }
}
