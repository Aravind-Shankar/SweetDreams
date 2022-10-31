using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidDispenser : MonoBehaviour
{
    //public GameObject cupPrefab;
    private Inventory inventory;
    public GameObject dispensedObject;

    private void Awake()
    {
        inventory = FindObjectOfType<Inventory>();
    }

    public void DispenseLiquid()
    {
        ItemType currItemType = inventory.GetItemType();
        if (currItemType == ItemType.emptyPotion)
        {
            // fill up cup
            // aka replace item with standard potion
            //GameObject drink = inventory.GetCurrentItem();
            //ItemData drinkData = drink.GetComponent<ItemData>();
            //drinkData.hasLiquid = true;
            GameObject standardPotion = Instantiate(dispensedObject, new Vector3(-1, -1, -1), Quaternion.identity);
            
            ItemData drinkData = standardPotion.GetComponent<ItemData>();
            drinkData.type = ItemType.standardPotion;

            inventory.SetItem(standardPotion);

            // if replacing standard potion item with filled potion entirely, this is not needed
            //Transform drinkFill = drink.transform.GetChild(1);
            //drinkFill.gameObject.GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(0, 0));
            //var drinkRenderer = drink.GetComponent<MeshRenderer>();
            //drinkRenderer.material.SetTextureOffset(
            Debug.Log("Filled with Liquid");
        } else if (currItemType == ItemType.standardPotion || currItemType == ItemType.victoryPotion)
        {
            Debug.Log("Your potion already has liquid!");
        }
        else
        {
            Debug.Log("No Drink in hand!");
        }
    }
}
