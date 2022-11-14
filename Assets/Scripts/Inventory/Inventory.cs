using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public PotionSO potionSO;
    public PotionPanel inHandPotionPanel;

    public Dictionary<int, int> inHandIngredientFrequency = new Dictionary<int, int>();

    [HideInInspector]
    public GameObject currentItem;
    [HideInInspector]
    public GameObject emptyItem;

    private ItemData currentItemData;

    private void Awake()
    {
        emptyItem = new GameObject();
        currentItem = emptyItem;
        UpdateHeldPotion();

        EventManager.StartListening("Drop", DropItem);
    }

    public ref GameObject GetCurrentItem()
    {
        return ref currentItem;
    }

    private void UpdateHeldPotion()
    {
        PotionRenderHelper renderHelper = currentItem.GetComponent<PotionRenderHelper>();

        if (GetItemType() == ItemType.validPotion)
        {
            Potion inHandPotion = potionSO.FindMatchingPotion(inHandIngredientFrequency);
            inHandPotionPanel.SetPotion(inHandPotion, inHandPotion != potionSO.wildcardPotion);
            if (renderHelper)
                renderHelper.ColorPotion(true, inHandPotion.potionColor);
        }
        else
        {
            inHandIngredientFrequency.Clear();
            inHandPotionPanel.Clear();
            if (GetItemType() == ItemType.emptyPotion && renderHelper)
                renderHelper.ColorPotion(false, Color.black);
        }
    }

    public bool AddIngredient(Ingredient ingredient)
    {
        if (GetItemType() != ItemType.validPotion)
            return false;

        int ingredientID = ingredient.id;
        if (inHandIngredientFrequency.ContainsKey(ingredientID))
            inHandIngredientFrequency[ingredientID]++;
        else
            inHandIngredientFrequency[ingredientID] = 1;
        UpdateHeldPotion();
        return true;
    }

    public void SetItem(GameObject o)
    {
        currentItem.transform.position = new Vector3(-50, -50, -50);
        currentItem = o;

        currentItemData = currentItem.GetComponent<ItemData>();
        UpdateHeldPotion();
    }

    public void RemoveItem()
    {
        if (!HasItem())
            return;

        // move item back below stage
        currentItem.transform.position = new Vector3(-50, -50, -50);

        currentItem = emptyItem;
        currentItemData = null;
        UpdateHeldPotion();
    }

    public void DropItem()
    {
        if (!HasItem())
            return;

        currentItem.AddComponent<Rigidbody>();
        currentItem.AddComponent<SphereCollider>();

        currentItem = emptyItem;
        currentItemData = null;
        UpdateHeldPotion();
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
