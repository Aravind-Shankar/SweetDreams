using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public PotionSO potionSO;
    public PotionPanel inHandPotionPanel;

    [HideInInspector]
    public GameObject currentItem;
    [HideInInspector]
    public GameObject emptyItem;

    private InventoryRenderer inventoryRenderer;
    private ItemData currentItemData;

    private void Awake()
    {
        emptyItem = new GameObject();
        currentItem = emptyItem;
        inHandPotionPanel.Clear();

        EventManager.StartListening("Drop", DropItem);
    }

    public ref GameObject GetCurrentItem()
    {
        return ref currentItem;
    }

    public void SetItem(GameObject o)
    {
        currentItem.transform.position = new Vector3(-50, -50, -50);
        currentItem = o;

        currentItemData = currentItem.GetComponent<ItemData>();
        bool potionAbsent = true;
        foreach (var potion in potionSO.potions)
        {
            if (potion.itemType == currentItemData.type)
            {
                inHandPotionPanel.SetPotion(potion);
                potionAbsent = false;
                break;
            }
        }
        if (potionAbsent)
            inHandPotionPanel.Clear();
    }

    public void RemoveItem()
    {
        if (!HasItem())
            return;

        // move item back below stage
        currentItem.transform.position = new Vector3(-50, -50, -50);

        currentItem = emptyItem;
        currentItemData = null;
        inHandPotionPanel.Clear();
    }

    public void DropItem()
    {
        if (!HasItem())
            return;

        currentItem.AddComponent<Rigidbody>();
        currentItem.AddComponent<SphereCollider>();

        currentItem = emptyItem;
        currentItemData = null;
        inHandPotionPanel.Clear();
    }

    public bool HasItem()
    {
        return currentItem != emptyItem;
    }

    public ItemType GetItemType()
    {
        return currentItemData == null ? ItemType.noItem : currentItemData.type;
    }
    // create a floating inventory over the player, rather than having a UI
    // potentially just do a minecraft inventory, or have a clock on the top right and the inventory on the top left
}
