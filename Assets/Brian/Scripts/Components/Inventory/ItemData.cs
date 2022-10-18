using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData : MonoBehaviour
{

    public System.Guid id;
    public string title { get; set; } 

    public bool hasLiquid { get; set; }
    public HashSet<IngredientData> ingredientData;

    public ItemData(string title)
    {
        this.id = System.Guid.NewGuid();
        this.title = title;
        this.hasLiquid = false;
        this.ingredientData = new HashSet<IngredientData>();
    }
}
