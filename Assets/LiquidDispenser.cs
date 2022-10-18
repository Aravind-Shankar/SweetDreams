using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidDispenser : MonoBehaviour
{
    //public GameObject cupPrefab;
    private Inventory inventory;

    private void Awake()
    {
        inventory = FindObjectOfType<Inventory>();
    }

    public void DispenseLiquid()
    {
        if (inventory.ContainsItem("Drink"))
        {
            // fill up cup
            GameObject drink = inventory.GetItem("Drink");
            ItemData drinkData = drink.GetComponent<ItemData>();
            drinkData.hasLiquid = true;

            var drinkRenderer = drink.GetComponent<MeshRenderer>();
            drinkRenderer.material.SetColor("_Color", Color.cyan);
        }
        else
        {
            Debug.Log("No Drink in hand!");
        }
    }
}
