using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public PotionSO potionSO;
    public PotionPanel inHandPotionPanel;

    public Dictionary<string, int> inHandIngredientFrequency = new Dictionary<string, int>();

    [HideInInspector]
    public GameObject currentItem;
    [HideInInspector]
    public GameObject emptyItem;

    private ItemData currentItemData;
    private ControlsViewManager _controlsViewManager;

    private void Awake()
    {
        emptyItem = new GameObject();
        currentItem = emptyItem;
    }

    private void Start()
    {
        _controlsViewManager = FindObjectOfType<ControlsViewManager>();

        EventManager.StartListening("Drop", DropItem);
        UpdateHeldPotion();
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
            Potion inHandPotion = potionSO.LookupPotionByIngredients(inHandIngredientFrequency);
            inHandPotionPanel.SetPotion(inHandPotion, inHandPotion != potionSO.wildcardPotion);
            if (renderHelper)
                renderHelper.ColorPotion(true, inHandPotion.color);
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

        string ingredientName = ingredient.name;
        if (inHandIngredientFrequency.ContainsKey(ingredientName))
            inHandIngredientFrequency[ingredientName]++;
        else
            inHandIngredientFrequency[ingredientName] = 1;

        UpdateHeldPotion();
        return true;
    }

    public void SetItem(GameObject o)
    {
        currentItem.transform.position = new Vector3(-50, -50, -50);
        currentItem = o;

        currentItemData = currentItem.GetComponent<ItemData>();
        UpdateHeldPotion();

        _controlsViewManager.dropKeyPanel.SetState(true, "Drop Held Item");
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

        _controlsViewManager.dropKeyPanel.SetState(false);
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

        EventLog.LogInfo("Dropped item in hand.");

        _controlsViewManager.dropKeyPanel.SetState(false);
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
