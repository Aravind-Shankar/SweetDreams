using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ingredients", menuName = "ScriptableObjects/IngredientSO", order = 1)]
public class IngredientSO : ScriptableObject
{
    [Tooltip("Ensure: array indices match the ids of the respective elements.")]
    public Ingredient[] ingredients;
}

[System.Serializable]
public class Ingredient
{
    public string name;
    public int id;
    public int cost;
    //public Sprite icon;
    //public ItemType itemType;
}