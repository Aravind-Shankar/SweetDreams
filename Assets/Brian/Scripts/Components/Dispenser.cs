using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dispenser : MonoBehaviour
{
    //public GameObject cupPrefab;
    public Inventory inventory;
    public GameObject dispensedObject;
    public GameObject player;

    private void Awake()
    {
        inventory = FindObjectOfType<Inventory>();
        player = GameObject.FindGameObjectWithTag("Player");
        //cup = Instantiate(cupPrefab, new Vector3(-1, -1, -1), Quaternion.identity);
    }

    public void Dispense()
    {
        // play cup dispensing sound
        // play particles for dispensing a cup
        //cup.transform.position = this.transform.position + new Vector3(0, 0, 3);
        // put it in player inventory


        ItemData item = dispensedObject.GetComponent<ItemData>();



        if (!inventory.HasItem())
        {
            Debug.Log("Dispense");
            GameObject newCup = Instantiate(dispensedObject, new Vector3(-1, -1, -1), Quaternion.identity);
            
            ItemData drinkData = newCup.GetComponent<ItemData>();
            drinkData.title = "Drink";
            drinkData.type = ItemType.emptyPotion;

            inventory.SetItem(newCup);


            //// make cup child of polyman
            //// to be replaced with inventory renderer code
            //newCup.transform.SetParent(player.transform);

            //newCup.transform.localPosition = new Vector3(.5f, 1, .5f);
        }
        else if (inventory.GetItemType() == ItemType.emptyPotion
                   || inventory.GetItemType() == ItemType.standardPotion
                   || inventory.GetItemType() == ItemType.victoryPotion)
        {
            // error say you already have cup
            Debug.Log("You already have a potion!!");
        } else
        {
            Debug.Log("You don't have space!");
        }
    }
}
