using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidDispenser : MonoBehaviour
{
    //public GameObject cupPrefab;
    private Inventory inventory;
    public GameObject dispensedObject;

    public GameObject chamberParent;
    private ChamberHealthManager[] chamberHealthManagers;

    private void Awake()
    {
        inventory = FindObjectOfType<Inventory>();
        chamberHealthManagers = chamberParent.GetComponentsInChildren<ChamberHealthManager>();
    }

    private bool TryUseChamber()
    {
        int numChambers = chamberHealthManagers.Length;
        int rnd;
        ChamberHealthManager temp;

        for (int i = 0; i < numChambers - 1; i++)
        {
            rnd = Random.Range(i, numChambers);
            temp = chamberHealthManagers[i];
            chamberHealthManagers[i] = chamberHealthManagers[rnd];
            chamberHealthManagers[rnd] = temp;
        }

        foreach (ChamberHealthManager chm in chamberHealthManagers)
        {
            if (chm.UseForDrink())
            {
                //print($"Used chamber: {chm.gameObject.name}");
                return true;
            }
        }
        //print("No chamber available!");
        return false;
    }

    public void DispenseLiquid()
    {
        ItemType currItemType = inventory.GetItemType();
        if (currItemType == ItemType.emptyPotion)
        {
            if (TryUseChamber())
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
                EventLog.LogInfo("Filled bottle with Dream Liquid.");
            }
            else
            {
                EventLog.LogError("Filling liquid failed due to low chamber health!");
            }
        }
        else if (currItemType == ItemType.standardPotion || currItemType == ItemType.victoryPotion)
        {
            EventLog.LogError("Your potion already has dream liquid!");
        }
        else
        {
            EventLog.LogError("No bottle in hand - can't fill dream liquid!");
        }
    }
}
