using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dispenser : MonoBehaviour
{
    //public GameObject cupPrefab;
    private Inventory inventory;
    public GameObject dispensedObject;
    public ItemType objectType;
    public string dispensedMessage;

    private void Awake()
    {
        inventory = FindObjectOfType<Inventory>();
    }

    public void Dispense()
    {
        if (!inventory.HasItem())
        {
            GameObject newObject = Instantiate(dispensedObject, new Vector3(-1, -1, -1), Quaternion.identity);
            
            ItemData itemData = newObject.GetComponent<ItemData>();
            itemData.type = objectType;

            inventory.SetItem(newObject);
            if (dispensedMessage != null && dispensedMessage != "")
                EventLog.LogInfo(dispensedMessage);
        }
        else
        {
            EventLog.LogError("Your hands are full, cannot dispense now!");
        }
    }
}
