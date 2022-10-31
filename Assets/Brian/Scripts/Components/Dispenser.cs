using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dispenser : MonoBehaviour
{
    //public GameObject cupPrefab;
    private Inventory inventory;
    public GameObject dispensedObject;
    public ItemType objectType;

    private GameObject player;

    private void Awake()
    {
        inventory = FindObjectOfType<Inventory>();
        player = GameObject.FindGameObjectWithTag("Player");
        //cup = Instantiate(cupPrefab, new Vector3(-1, -1, -1), Quaternion.identity);
    }

    public void Dispense()
    {
        ItemData item = dispensedObject.GetComponent<ItemData>();

        if (!inventory.HasItem())
        {
            Debug.Log("Dispense");
            GameObject newCup = Instantiate(dispensedObject, new Vector3(-1, -1, -1), Quaternion.identity);
            
            ItemData drinkData = newCup.GetComponent<ItemData>();
            drinkData.type = objectType;

            inventory.SetItem(newCup);
        }
        else
        {
            Debug.Log("Your hands are full!");
        }
    }
}
