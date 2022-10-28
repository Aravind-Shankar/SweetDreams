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

            Transform drinkFill = drink.transform.GetChild(1);
            drinkFill.gameObject.GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(0, 0));
            //var drinkRenderer = drink.GetComponent<MeshRenderer>();
            //drinkRenderer.material.SetTextureOffset(
            Debug.Log("Filled with Liquid");
        }
        else
        {
            Debug.Log("No Drink in hand!");
        }
    }
}
