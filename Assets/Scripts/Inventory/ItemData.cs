using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData : MonoBehaviour
{

    public System.Guid id;

    public bool hasLiquid { get; set; }
    public ItemType type { get; set; }
    //public HashSet<IngredientData> ingredientData;

    public ItemData(string title)
    {
        this.id = System.Guid.NewGuid();
        this.hasLiquid = false;
        //this.ingredientData = new HashSet<IngredientData>();
    }
}

public enum ItemType
{
    emptyPotion, // potion 0
    standardPotion, // 1
    victoryPotion, // 2
    chamberFood,
    victoryExtract,
    noItem,
}