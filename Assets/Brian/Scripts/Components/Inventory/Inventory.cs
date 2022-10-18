using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<GameObject> inventory;
    private void Awake()
    {
        inventory = new List<GameObject>();
    }

    public void AddItem(GameObject item)
    {
        inventory.Add(item);
    }

    public GameObject GetItem(int index)
    {
        return inventory[index];
    }

    public GameObject GetItem(string title)
    {
        return inventory.Find(x => x.GetComponent<ItemData>().title == title);
    }

    public bool ContainsItem(string title)
    {
        return inventory.Exists(x => x.GetComponent<ItemData>().title == title);
    }

    public void DestroyItem(string title)
    {
        GameObject item = this.GetItem(title);
        inventory.Remove(item);
        Destroy(item);
    }

    // create a floating inventory over the player, rather than having a UI
    // potentially just do a minecraft inventory, or have a clock on the top right and the inventory on the top left
}
