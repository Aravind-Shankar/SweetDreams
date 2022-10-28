using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject inventory;
    public GameObject emptyItem;
    private void Awake()
    {
        //inventory = new List<GameObject>();
        inventory = emptyItem;
    }


    public void SetItem(GameObject o)
    {
        inventory = o;
    }

    public void RemoveItem()
    {
        // destroy GameObject first then remove from dictionary
        inventory = emptyItem;
    }

    public bool HasItem()
    {
        return inventory == emptyItem;
    }

    public string GetItemType()
    {
        ItemData data = inventory.GetComponent<ItemData>();
        if (inventory != emptyItem && data != null) 
        {
            return data.title;
        }
        return "";
    }
    // create a floating inventory over the player, rather than having a UI
    // potentially just do a minecraft inventory, or have a clock on the top right and the inventory on the top left
}
