using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject currentItem;
    public GameObject emptyItem;
    private InventoryRenderer inventoryRenderer;
    private void Awake()
    {
        emptyItem = new GameObject();
        currentItem = emptyItem;
    }

    public ref GameObject GetCurrentItem()
    {
        return ref currentItem;
    }

    public void SetItem(GameObject o)
    {
        currentItem.transform.position = new Vector3(-50, -50, -50);
        currentItem = o;
    }

    public void RemoveItem()
    {
        // move item back below stage
        currentItem.transform.position = new Vector3(-50, -50, -50);

        currentItem = emptyItem;
    }

    public bool HasItem()
    {
        Debug.Log(currentItem != emptyItem);
        return currentItem != emptyItem;
    }

    public ItemType GetItemType()
    {
        ItemData data = currentItem.GetComponent<ItemData>();

        if (data == null)
        {
            return ItemType.noItem;
        }

        return data.type;

    }
    // create a floating inventory over the player, rather than having a UI
    // potentially just do a minecraft inventory, or have a clock on the top right and the inventory on the top left
}
